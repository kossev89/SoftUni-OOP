using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] fields)
        {
            Type classType = Type.GetType(classToInvestigate);
            FieldInfo[] classFields = classType.GetFields(
                BindingFlags.Instance
                | BindingFlags.NonPublic
                | BindingFlags.Public
                );

            StringBuilder sb = new();
            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {classToInvestigate}");
            foreach (var field in classFields.Where(f => fields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().Trim();

        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields
                (
                BindingFlags.Instance
                | BindingFlags.Static
                | BindingFlags.Public
                );
            MethodInfo[] classPublicMethods = classType.GetMethods
                (
                BindingFlags.Instance
                | BindingFlags.Public
                );
            MethodInfo[] classNonPublicMethods = classType.GetMethods
              (
              BindingFlags.Instance
              | BindingFlags.NonPublic
              );

            StringBuilder sb = new();

            foreach (var field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (var method in classPublicMethods.Where(m=>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in classNonPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            return sb.ToString().Trim();
        }
    }
}
