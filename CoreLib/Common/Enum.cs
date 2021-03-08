using System;
using System.ComponentModel;
using System.Reflection;

namespace CoreLib.Common
{
    public static class EnumUtils
    {
        public static string ValueOf(Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = (DescriptionAttribute) fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute.Description;
        }

        public static object EnumValueOf(string value , Type enum_type)
        {
            string[] names = Enum.GetNames(enum_type);
            foreach( string name in names )
            {
                if( ValueOf((Enum) Enum.Parse(enum_type , name)).Equals(value) )
                    return Enum.Parse(enum_type , name);
            }
            throw new ArgumentException("Строка не описана или не задана.");
        }

        public static string[] CollectionValueOf(Type enum_type)
        {
            Array enums = Enum.GetValues(enum_type);
            string[] values = new string[enums.Length];
            int i = 0;
            foreach( object val in enums )
            {
                values[i] = EnumUtils.ValueOf((Enum) val);
                i++;
            }
            return values;
        }
    }

    public enum Direction
    {
        /// <summary>
        /// Автодор
        /// </summary>
        car = 1,
        /// <summary>
        /// Желдор
        /// </summary>
        train = 2
    }

    public enum TestType
    {
        [DescriptionAttribute("Обучающего тестирования")]
        training,
        [DescriptionAttribute("Итогового тестирования")]
        control
    }
    public enum ExerciseType
    {
        [DescriptionAttribute("Тестовые вопросы")]
        common,
        [DescriptionAttribute("Тематические вопросы")]
        themen,
        [DescriptionAttribute("Практические задачи")]
        practical
    };
}
