using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBProjWF
{
    class IniParser
    {
        static Dictionary<string,object> __parse(string buffer)
        {
            var result = new Dictionary<string, object>();
            var lines = buffer.Split('\n');
            Dictionary<string, object> current_section = null;
            foreach (string line_original in lines)
            {
                string line = line_original.Trim();
                bool isComment = line.StartsWith(";");
                bool IsSection = line.StartsWith("[") && line.EndsWith("]");

                if (isComment)
                    continue;

                if (IsSection)
                {
                    string section_name = line.Remove(0, 1).Remove(line.Length - 2, 1);
                    Dictionary<string, object> section = new Dictionary<string, object>();
                    current_section = section;
                    result.Add(section_name, section);
                    continue;
                }

                var elems = line.Split('=');
                string left = elems[0].Trim();
                string right = elems[1].Trim();

                object final = right;
                int v_int;
                float v_float;
                bool v_bool;

                // Parse 가 되는지 확인한다.
                if (int.TryParse(right, out v_int))
                    final = v_int;
                if (right.Contains("."))
                {
                    if (float.TryParse(right, out v_float))
                        final = v_float;
                }

                // bool 여부 판정
                switch (right.ToLower())
                {
                    case "yes":
                        final = true;
                        break;
                    case "no":
                        final = false;
                        break;
                }
                if (current_section != null)
                    current_section.Add(left, final);
                else
                    result.Add(left, final);
            }


            return result;
        }
        /// <summary>
        /// 경로로부터 INI 를 읽어와 Dictionary 형태로 리턴한다.
        /// </summary>
        /// <param name="path">INI 경로.</param>
        /// <returns></returns>
        public static Dictionary<string,object> Read(string path)
        {
            try
            {
                return __parse(File.ReadAllText(path));
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("해당 INI 파일을 찾을 수 없습니다. : " + path);
                return null;
            }
        }
    }
}
