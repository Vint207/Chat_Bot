﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using static System.Console;

namespace Chat_Bot
{
    sealed class Validation
    {

        public static void TryValidate(object obj, string propertyName)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);

            while (true)
            {
                try
                {
                    switch (Type.GetTypeCode(propertyInfo.PropertyType))
                    {
                        case TypeCode.Empty:
                            propertyInfo.SetValue(obj, ReadLine());
                            break;
                        case TypeCode.String:
                            propertyInfo.SetValue(obj, ReadLine());
                            break;
                        case TypeCode.Int32:
                            propertyInfo.SetValue(obj, Convert.ToInt32(ReadLine())); 
                            break;
                        case TypeCode.Double:
                            propertyInfo.SetValue(obj, Convert.ToDouble(ReadLine()));                         
                            break;
                    }

                    var propertyValue = propertyInfo.GetValue(obj);
                    var results = new List<ValidationResult>();
                    var context = new ValidationContext(obj) { MemberName = propertyName };

                    if (Validator.TryValidateProperty(propertyValue, context, results)) { break; }

                    foreach (var item in results) { WriteLine(item.ErrorMessage); }
                }
                catch (Exception ex) { WriteLine(ex.Message); }; 
            }
        }
    }
}
