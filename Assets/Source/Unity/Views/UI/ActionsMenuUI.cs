using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DefaultEcs;
using Source.Common;
using Source.Common.Extensions;
using Source.GGJ2020.Commands;
using Source.GGJ2020.Features.ActionsFeature.Components;
using Source.GGJ2020.Messages;
using UnityEngine;

namespace Source.Unity.Views.UI {
    public class ActionsMenuUI : EntityView {
        public GameObject ActionItemPrefab;
        private Dictionary<IAction, ActionItemUI> items = new Dictionary<IAction, ActionItemUI>(5);
        private int CurrentActiveItem = 0;

        private Entity SkeletonEntity;

        public void SetSkeletonEntity(Entity entity) {
            SkeletonEntity = entity;
        }

        private void Awake() {
            World world = Container.Resolve<World>();
            world.Subscribe<CancelMessage>(delegate {
                if (!gameObject.activeSelf) return;
                gameObject.SetActive(false);
            });
            world.Subscribe<MoveMessage>(delegate(in MoveMessage msg) {
                if (!gameObject.activeSelf) return;
                if (msg.Type == MovementType.Up) {
                    int currentActiveItem = (CurrentActiveItem - 1) % items.Count;
                    SelectItem(currentActiveItem < 0 ? items.Count - 1 : currentActiveItem);
                } else if (msg.Type == MovementType.Down) {
                    SelectItem((CurrentActiveItem + 1) % items.Count);
                }
            });

            world.Subscribe<SubmitMessage>(delegate {
                if (!gameObject.activeSelf) return;
                int i = 0;
                IAction action = null;
                foreach (var item in items) {
                    if (i == CurrentActiveItem) {
                        action = item.Key;
                    }

                    i++;
                }

                SkeletonEntity.ApplyCommand(new SelectActionTargetCommand(action));

                gameObject.SetActive(false);
            });
        }

        public override void Render(Entity entity) {
            List<IAction> actions = entity.Get<ActionsContainerComponent>().Value;
            foreach (var action in actions) {
                if (!items.ContainsKey(action)) {
                    var go = Instantiate(ActionItemPrefab, transform);
                    ActionItemUI ui = go.GetComponent<ActionItemUI>();
                    ui.Initialize(action);
                    items.Add(action, ui);
                }
            }
        }

        private void SelectItem(int idx) {
            int i = 0;
            foreach (var item in items) {
                if (i == CurrentActiveItem) {
                    item.Value.SetSelected(false);
                }

                i++;
            }

            i = 0;
            foreach (var item in items) {
                if (i == idx) {
                    item.Value.SetSelected(true);
                    CurrentActiveItem = idx;
                }

                i++;
            }
        }

        public void Reset() {
            int i = 0;
            CurrentActiveItem = 0;
            foreach (var item in items) {
                item.Value.SetSelected(i == CurrentActiveItem);
                i++;
            }
        }
    }
}