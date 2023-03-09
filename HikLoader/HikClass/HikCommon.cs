using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HikUnLoader.HikClass
{
    /// <summary>
    /// 相机名称枚举
    /// </summary>
    public enum CameraName
    {
        /// <summary>相机1,对应索引是1而不是0 </summary>
        相机1 = 1,
        /// <summary>相机2 </summary>
        相机2,
        /// <summary>相机3 </summary>
        相机3,
        /// <summary>相机4 </summary>
        相机4,
    }

    /// <summary>
    /// 静态参数类
    /// </summary>
    public static class Parameter
    {
        /// <summary>
        /// 是否是17寸的产品，1表示是，-1表示否
        /// </summary>
        public static double ProductIs17Inch;

        /// <summary>
        /// 17寸产品的长边像素距离
        /// </summary>
        public static double LongEdgeOf17InchPro;

        /// <summary>
        /// 17寸产品的短边像素距离
        /// </summary>
        public static double ShortEdgeOf17InchPro;

        /// <summary>
        /// 视觉系统历史运行扫码OK次数
        /// </summary>
        public static double OKCountOfHistoryCodeScan;

        /// <summary>
        /// 视觉系统历史运行扫码OK次数
        /// </summary>
        public static double NGCountOfHistoryCodeScan;
        /// <summary>
        /// 产品的最大个数
        /// </summary>
        public static int productMax;

        /// <summary> 
        /// PLC客户端 
        /// </summary>
        public static TcpClient PLC_Client;

        /// <summary>
        /// PLC的IP地址
        /// </summary>
        public static string PLCIP;

        /// <summary>
        /// PLC的端口号
        /// </summary>
        public static int PLCPort;

        /// <summary>
        /// 当前料号实时发送到PLC地址
        /// </summary>
        public static int Address_CurrentProductSendToPLC;

        /// <summary>
        /// 料号切换触发信号地址
        /// </summary>
        public static int Address_ProductChangeTrigger;

        /// <summary>
        /// PLC当前料号地址
        /// </summary>
        public static int Address_PLCCurrentProduct;

        /// <summary>程序Ready信号</summary>
        public static int Address_CamerRady;

        /// <summary>相机1触发拍照信号地址</summary>
        public static int Address_Camer1CF;

        /// <summary>相机2触发拍照信号</summary>
        public static int Address_Camer2CF;

        /// <summary>相机2模式 1正反 2定位 3标定</summary>
        public static int Camer2MS;

        /// <summary>
        /// 读码器触发信号地址
        /// </summary>
        public static int Address_TriggerSignalOfCodeReader;

        /// <summary>
        /// 读码器端口
        /// </summary>
        public static string CodeReaderPort;

        /// <summary>读码器读码OK,NG信号</summary>
        public static int Address_CodeReaderOK;

        /// <summary>
        /// 发送给PLC的读码数据开始地址
        /// </summary>
        public static int Address_CodeReaderData;

        /// <summary>
        /// 通知PLC相机1开始自动标定信号地址
        /// </summary>
        public static int Address_Camer1CalibStart;

        /// <summary>
        /// 通知PLC相机2开始自动标定信号地址
        /// </summary>
        public static int Address_Camer2CalibStart;

        /// <summary>
        /// 相机1标定起始点X地址
        /// </summary>
        public static int Address_Cam1CalibStartPointX;

        /// <summary>
        /// 相机1标定起始点Y地址
        /// </summary>
        public static int Address_Cam1CalibStartPointY;

        /// <summary>
        /// 相机1示教位X地址:PLC的取料基准位X
        /// </summary>
        public static int Address_Cam1BasePointX;

        /// <summary>
        /// 相机1示教位Y地址:PLC的取料基准位Y
        /// </summary>
        public static int Address_Cam1BasePointY;

        /// <summary>
        /// 相机1自动12点标定时X偏移量地址
        /// </summary>
        public static int Address_Cam1CalibOffsetX;

        /// <summary>
        /// 相机1自动12点标定时Y偏移量地址
        /// </summary>
        public static int Address_Cam1CalibOffsetY;

        /// <summary>
        /// 相机1发送X值到PLC的地址
        /// </summary>
        public static int Address_Cam1XSendToPLC;

        /// <summary>
        /// 
        /// 相机1发送Y值到PLC的地址
        /// </summary>
        public static int Address_Cam1YSendToPLC;

        /// <summary>
        /// 
        /// 相机1发送角度值到PLC的地址
        /// </summary>
        public static int Address_Cam1AngleSendToPLC;

        /// <summary>
        /// 相机1标定原点X
        /// </summary>
        public static double Cam1CalibCentralPointX;

        /// <summary>
        /// 相机1标定原点Y 
        /// </summary>
        public static double Cam1CalibCentralPointY;

        /// <summary>
        /// 相机1自动12点标定时X偏移量
        /// </summary>
        public static double Cam1CalibOffsetX;

        /// <summary>
        /// 相机2自动12点标定时Y偏移量
        /// </summary>
        public static double Cam1CalibOffsetY;

        /// <summary>
        /// 相机1示教位X
        /// </summary>
        public static double Cam1BasePointX;

        /// <summary>
        /// 相机1示教位Y
        /// </summary>
        public static double Cam1BasePointY;

        /// <summary>
        /// 相机1示教位角度
        /// </summary>
        public static double Cam1baseAngle1;

        /// <summary>
        /// 相机1标定转化后的X
        /// </summary>
        public static double Cam1CalibConversionX;

        /// <summary>
        /// 相机1标定转化后的Y
        /// </summary>
        public static double Cam1CalibConversionY;

        /// <summary>相机1 OK,NG结果地址</summary>
        public static int Address_Cam1Result;

        /// <summary>相机2 OK,NG结果地址,OK1,NG2</summary>
        public static int Address_Cam2Result;

        /// <summary>相机2，正反地址  0正1反</summary>
        public static int Camera2Direction;

        /// <summary>
        /// 相机2标定起始点X坐标地址
        /// </summary>
        public static int Address_Cam2CalibStartPointX;

        /// <summary>
        /// 相机2标定起始点Y坐标地址
        /// </summary>
        public static int Address_Cam2CalibStartPointY;

        /// <summary>
        /// 相机2自动12点标定时X偏移量地址
        /// </summary>
        public static int Address_Cam2CalibOffsetX;

        /// <summary>
        /// 相机2自动12点标定时Y偏移量地址
        /// </summary>
        public static int Address_Cam2CalibOffsetY;

        /// <summary>
        /// 相机2正面示教位X坐标地址
        /// </summary>
        public static int Address_Cam2FrontBasePointX;

        /// <summary>
        /// 相机2正面示教位Y坐标地址
        /// </summary>
        public static int Address_Cam2FrontBasePointY;

        /// <summary>
        /// 相机2反面示教位X坐标地址
        /// </summary>
        public static int Address_Cam2BasePointXOfOpposite;

        /// <summary>
        /// 相机2反面示教位Y坐标地址
        /// </summary>
        public static int Address_Cam2BasePointYOfOpposite;

        /// <summary>
        /// 相机2发送X值到PLC的地址
        /// </summary>
        public static int Address_Cam2XDataSendToPLC;

        /// <summary>
        /// 相机2发送Y值到PLC的地址
        /// </summary>
        public static int Address_Cam2YDataSendToPLC;

        /// <summary>
        /// 相机2发送角度值到PLC的地址
        /// </summary>
        public static int Address_Cam2AngleSendToPLC;

        /// <summary>相机1从文件取像的路径 </summary>
        public static string Camera1imagePath = null;

        /// <summary>相机2从文件取像的路径 </summary>
        public static string Camera2imagePath = null;

        /// <summary>
        /// 相机2标定原点X坐标
        /// </summary>
        public static double Cam2CalibCentralPointX;

        /// <summary>
        /// 相机2标定原点Y坐标
        /// </summary>
        public static double Cam2CalibCentralPointY;

        /// <summary>
        /// 相机2自动12点标定时X偏移量
        /// </summary>
        public static double Cam2CalibOffsetX;

        /// <summary>
        /// 相机2自动12点标定时Y偏移量
        /// </summary>
        public static double Cam2CalibOffsetY;

        /// <summary>
        /// 相机2正面标定转化后的X
        /// </summary>
        public static double Cam2CalibConversionXOfFront;

        /// <summary>
        /// 相机2正面标定转化后的Y
        /// </summary>
        public static double Cam2CalibConversionYOfFront;

        /// <summary>
        /// 相机2正面示教点X坐标的值
        /// </summary>
        public static double Cam2BasePointXOfFront;

        /// <summary>
        /// 相机2正面示教点Y坐标的值 
        /// </summary>
        public static double Cam2BasePointYOfFront;

        /// <summary>
        /// 相机2正面示教位角度 
        /// </summary>
        public static double Camera2BaseAngleOfFront;

        /// <summary>
        /// 相机2反面标定转化后的X
        /// </summary>
        public static double Cam2CalibConversionXOfOpposite;

        /// <summary>
        /// 相机2反面标定转化后的Y
        /// </summary>
        public static double Cam2CalibConversionYOfOpposite;

        /// <summary>
        /// 相机2反面示教位X坐标
        /// </summary>
        public static double Cam2BasePointXOfOpposite;

        /// <summary>
        /// 相机2反面示教位Y坐标
        /// </summary>
        public static double Cam2BasePointYOfOpposite;

        /// <summary>
        /// 相机2反面示教位角度
        /// </summary>
        public static double Cam2BaseAngleOfOpposite;



        /// <summary>判断能否将字符串转化为int </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsNumberic(string str)

        {

            int vsNum;

            bool isNum;

            isNum = Int32.TryParse(str, out vsNum);

            return isNum;

        }
    }

    /// <summary>
    /// 结果类
    /// </summary>
    public class Result
    {
        /// <summary> X坐标 </summary>
        public double X;

        /// <summary> Y坐标 </summary>
        public double Y;

        /// <summary> 角度 </summary>
        public double Angle;

        /// <summary> X结果 </summary>
        public bool Xresult;

        /// <summary> Y结果 </summary>
        public bool Yresult;

        /// <summary> 角度结果 </summary>
        public bool Angleresult;
    }
}
