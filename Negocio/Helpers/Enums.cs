using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model.Helpers
{
    public static class Enums
    {
        public enum ECargo
        {
            [Description("Presidente")]
            PRESIDENTE = 1,
            [Description("Prefeito")]
            PREFEITO = 2,
            [Description("Vereador")]
            VEREADOR = 3,
            [Description("Governador")]
            GOVERNADOR = 4,
            [Description("Deputado Estadual")]
            DEPUTADO_ESTADUAL = 5,
            [Description("Deputado Federal")]
            DEPUTADO_FEDERAL = 6

        }
        public enum ETipoEleicao
        {
            [Description("Legislativo")]
            LEGISLATIVO = 1,
            [Description("Executivo")]
            EXECUTIVO = 2
        }

        public enum EStatusEleicao
        {
            [Description("Aberta")]
            ABERTA = 1,
            [Description("Finalizada")]
            FINALIZADA = 2,
            [Description("Finalizada com Segundo Turno")]
            FINALIZADA_SEGUNDO_TURNO = 3
        }

        #region Metodos para recuperar as descrições do enum
        public static string GetDescription<TEnum>(this TEnum EnumValue) where TEnum : Enum
        {
            return GetEnumDescription((Enum)(object)((TEnum)EnumValue));
        }
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo? fi = value.GetType().GetField(value.ToString());

            if (fi == null)
                return "";

            DescriptionAttribute[]? attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
        public static List<EnumHelperObject> ToSelectList<TEnum>() where TEnum : Enum
        {
            FieldInfo[] fi = typeof(TEnum).GetFields();
            List<EnumHelperObject> returnList = new List<EnumHelperObject>();

            foreach (FieldInfo fiEnum in fi)
            {

                DescriptionAttribute[]? attributes = fiEnum.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

                if (fiEnum.FieldType.IsEnum)
                {
                    if (attributes != null && attributes.Any())
                    {
                        returnList.Add(new EnumHelperObject() { Text = attributes.First().Description, Value = fiEnum.GetRawConstantValue() });
                    }
                    else
                    {
                        returnList.Add(new EnumHelperObject() { Text = fiEnum.Name, Value = fiEnum.GetRawConstantValue() });
                    }
                }

            }

            return returnList.OrderBy(x => x.Value).ToList();
        }

        #endregion
    }

    public class EnumHelperObject
    {
        public string? Text { get; set; }
        public object? Value { get; set; }
    }
}


