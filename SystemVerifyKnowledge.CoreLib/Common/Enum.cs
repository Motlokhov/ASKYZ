using System;
using System.ComponentModel;
using System.Reflection;

namespace SystemVerifyKnowledge.CoreLib.Common
{
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

    public enum ExerciseSetType
    {
        [Description("Обучающего тестирования")]
        Training,
        [Description("Итогового тестирования")]
        Grand
    }
    public enum ExerciseType
    {
        [Description("Тестовые вопросы")]
        common,
        [Description("Тематические вопросы")]
        themen,
        [Description("Практические задачи")]
        practical
    };
}
