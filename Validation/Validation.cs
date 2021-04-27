using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static System.Console;

namespace Chat_Bot
{
    sealed class Validation
    {

        public static void TryValidate(object obj, string propertyName)
        {
            while (true)
            {             
                TypeCode typeCode = Convert.GetTypeCode(obj.GetType().GetProperty(propertyName).GetValue(obj));

                try
                {
                    if (typeCode == TypeCode.Empty) obj.GetType().GetProperty(propertyName).SetValue(obj, ReadLine());
                    if (typeCode == TypeCode.String) obj.GetType().GetProperty(propertyName).SetValue(obj, ReadLine());
                    if (typeCode == TypeCode.Int32) obj.GetType().GetProperty(propertyName).SetValue(obj, Convert.ToInt32(ReadLine()));
                    if (typeCode == TypeCode.Int64) obj.GetType().GetProperty(propertyName).SetValue(obj, Convert.ToInt64(ReadLine()));
                    if (typeCode == TypeCode.UInt64) obj.GetType().GetProperty(propertyName).SetValue(obj, Convert.ToUInt64(ReadLine()));
                    if (typeCode == TypeCode.UInt32) obj.GetType().GetProperty(propertyName).SetValue(obj, Convert.ToUInt32(ReadLine()));
                    if (typeCode == TypeCode.UInt16) obj.GetType().GetProperty(propertyName).SetValue(obj, Convert.ToUInt16(ReadLine()));
                    if (typeCode == TypeCode.Double) obj.GetType().GetProperty(propertyName).SetValue(obj, Convert.ToDouble(ReadLine()));
                    if (typeCode == TypeCode.Boolean) obj.GetType().GetProperty(propertyName).SetValue(obj, Convert.ToBoolean(ReadLine()));
                    if (typeCode == TypeCode.Byte) obj.GetType().GetProperty(propertyName).SetValue(obj, Convert.ToByte(ReadLine()));
                }
                catch (Exception ex) { WriteLine(ex.Message); }

                var propertyValue = obj.GetType().GetProperty(propertyName).GetValue(obj);
                var results = new List<ValidationResult>();
                var context = new ValidationContext(obj) { MemberName = propertyName };

                if (Validator.TryValidateProperty(propertyValue, context, results)) { break; }

                foreach (var item in results)
                { WriteLine(item.ErrorMessage); }
            }
        }
    }
}
