using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HikUnLoader.HikClass
{
    /// <summary>
    /// INI配置文件读写静态类
    /// </summary>
    public static class INIManager
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
        private static extern uint GetPrivateProfileStringA(string section, string key, string def, byte[] retVal, int size, string filePath);

        /// <summary>
        /// 读取ini配置文件中所有的Section，返回字符串集合
        /// </summary>
        /// <param name="iniFilename">ini文件名称</param>
        /// <returns></returns>
        public static List<string> ReadSections(string iniFilename)
        {
            List<string> result = new List<string>();
            byte[] buf = new byte[65536];
            uint len = GetPrivateProfileStringA(null, null, null, buf, buf.Length, iniFilename);
            int j = 0;
            for (int i = 0; i < len; i++)
                if (buf[i] == 0)
                {
                    result.Add(Encoding.Default.GetString(buf, j, i - j));
                    j = i + 1;
                }
            return result;
        }

        /// <summary>
        /// 写入INI配置文件
        /// </summary>
        /// <param name="Section">段</param>
        /// <param name="Key">键</param>
        /// <param name="Value">值</param>
        /// <param name="filePath">INI文件路径</param>
        public static void IniWriteValue(string Section, string Key, string Value, string filePath)
        {
            WritePrivateProfileString(Section, Key, Value, filePath);
        }

        /// <summary>
        /// 从INI配置文件读取数据
        /// </summary>
        /// <param name="Section">段</param>
        /// <param name="Key">键</param>
        /// <param name="filePath">INI配置文件路径</param>
        /// <returns></returns>
        public static string IniReadValue(string Section, string Key, string filePath)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, filePath);
            return temp.ToString();
        }
    }
}
