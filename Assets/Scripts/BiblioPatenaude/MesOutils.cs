using System;
using System.Collections;

namespace ProjetTow2
{
    public static class MesOutils
    {
        /// <summary>
        /// Génère une chaîne de log pour un objet donné.
        /// </summary>
        /// <param name="variableName">Le nom de la variable.</param>
        /// <param name="variable">La valeur de la variable.</param>
        /// <returns>Une chaîne formatée sous la forme : &lt; nom de la Variable , (type de la variable) valeur de la variable &gt;</returns>
        public static string GetLogString(string variableName, object variable)
        {
            if (variable == null)
            {
                return $"< {variableName} , (null) null > , ";
            }

            Type variableType = variable.GetType();

            // Gérer les tableaux
            if (variable is IEnumerable && !(variable is string))
            {
                string arrayValues = "[";
                foreach (var item in (IEnumerable)variable)
                {
                    arrayValues += $"{item}, ";
                }
                arrayValues = arrayValues.TrimEnd(',', ' ') + "]";
                return $"< {variableName} , ({variableType.Name}) {arrayValues} > , ";
            }

            // Autres types
            return $"< {variableName} , ({variableType.Name}) {variable} > , ";
        }

        public static string GetFPS() { return (1.0f / UnityEngine.Time.deltaTime).ToString("F1"); }
    
    }
}
