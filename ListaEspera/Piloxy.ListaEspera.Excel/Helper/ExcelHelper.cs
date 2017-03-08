using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piloxy.ListaEspera.Application.Helper
{
    class ExcelHelper
    {
        public static T GetColumnNumberByName<T>(Dictionary<string,int> data,ExcelRange cells,int row,string name) where T:struct
        {
            var key = data.Keys.FirstOrDefault(d => d.ToLower() == name.ToLower());

            if (string.IsNullOrEmpty(key) && !data.ContainsKey(key))
                return default(T);

            var column = data[key];


            var valueCell = cells[row, column].Value;

            var input = valueCell != null ? valueCell.ToString() : "";

            if (string.IsNullOrEmpty(input))
                return default(T);

            if (typeof(T) == typeof(DateTime))
            {
                var parsedDate = (T)Convert.ChangeType(input, typeof(T));
                if (DateTime.MinValue.ToString() == parsedDate.ToString())
                    return default(T);

                return parsedDate;
            }

            try
            {
                return (T)Convert.ChangeType(input, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

        public static string GetColumnNumberByName(Dictionary<string, int> data, ExcelRange cells, int row, string name)
        {
            try
            {
                var key = data.Keys.FirstOrDefault(d => d.ToLower() == name.ToLower());

                if (string.IsNullOrEmpty(key) && !data.ContainsKey(key))
                    return "";
                
                var column = data[key];

                var valueCell = cells[row, column].Value;

                return valueCell != null ? valueCell.ToString() : "";
            }
            catch
            {
                return "";
            }
        }

        public static T GetColumnNumberByContainName<T>(Dictionary<string, int> data, ExcelRange cells, int row, string name) where T : struct
        {
            try
            {
                var key = data.Keys.FirstOrDefault(d => d.ToLower().Contains(name.ToLower()));
            
                if (string.IsNullOrEmpty(key) && !data.ContainsKey(key))
                    return default(T);
                
                var column = data[key];

                var valueCell = cells[row, column].Value;
                var input = valueCell != null ? valueCell.ToString() : "";

                if (string.IsNullOrEmpty(input))
                    return default(T);

                if (typeof(T) == typeof(DateTime))
                {
                    var parsedDate = (T)Convert.ChangeType(input, typeof(T));
                    if (DateTime.MinValue.ToString() == parsedDate.ToString())
                        return default(T);

                    return parsedDate;
                }

                return (T)Convert.ChangeType(input, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

        public static Nullable<T> GetColumnNumberByContainNameNullable<T>(Dictionary<string, int> data, ExcelRange cells, int row, string name) where T : struct
        {
            try
            {
                var key = data.Keys.FirstOrDefault(d => d.ToLower().Contains(name.ToLower()));

                if (string.IsNullOrEmpty(key) && !data.ContainsKey(key))
                    return default(T);

                var column = data[key];

                var valueCell = cells[row, column].Value;
                var input = valueCell != null ? valueCell.ToString() : "";

                if (string.IsNullOrEmpty(input))
                    return default(T);

                if (typeof(T) == typeof(DateTime))
                {
                    var parsedDate = (T)Convert.ChangeType(input, typeof(T));
                    if (DateTime.MinValue.ToString() == parsedDate.ToString())
                        return default(T);

                    return parsedDate;
                }

                return (T)Convert.ChangeType(input, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

        public static string GetColumnNumberByContainName(Dictionary<string, int> data, ExcelRange cells, int row, string name)
        {
            try
            {
                var key = data.Keys.FirstOrDefault(d => d.ToLower().Contains(name.ToLower()));

                if (string.IsNullOrEmpty(key) && !data.ContainsKey(key))
                    return "";

                var column = data[key];

                var valueCell = cells[row, column].Value;
                return valueCell != null ? valueCell.ToString() : "";
            }
            catch
            {
                return "";
            }
        }
    }
}
