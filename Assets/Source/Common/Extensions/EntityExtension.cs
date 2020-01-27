using System;
using System.Collections.Generic;
using DefaultEcs;
using DefaultEcs.Serialization;
using Source.GGJ2020.Commands;

namespace Source.Common.Extensions
{
    public static class EntityExtension
    {
        public static bool ApplyCommand(this Entity entity, ICommand command)
        {
            if (command.CheckConstraints(entity)) {
                command.Apply(entity);
                return true;
            }

            return false;
        }

        public static string Debug(this Entity entity)
        {
            DebugComponentReader reader = new DebugComponentReader();
            entity.ReadAllComponents(reader);

            return $"Entity ({entity}): {reader.Dump()}";
        }
    }

    class DebugComponentReader : IComponentReader
    {
        private readonly List<string> _components = new List<string>();

        public void OnRead<T>(ref T component, in Entity componentOwner)
        {
            string componentView = $"--------------\n{component}\n--------------\n";
            foreach (var prop in component.GetType().GetProperties()) {
                componentView += $"{prop.Name} = {prop.GetValue(component, null)}\n";
            }

            foreach (var field in component.GetType().GetFields()) {
                componentView += $"{field.Name} = {field.GetValue(component)}\n";
            }

            _components.Add(componentView);
        }

        void IComponentReader.OnRead<T>(ref T component, in Entity componentOwner)
        {
            OnRead(ref component, in componentOwner);
        }

        public string Dump()
        {
            return String.Join("\n", _components);
        }
    }
}