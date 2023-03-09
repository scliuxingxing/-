using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikUnLoader.HikClass
{
  public  class TypeDefine
    {
    }
    /// <summary>
    /// 结构体：结果数据行
    /// </summary>
    public class DataRow
    {
        /// <summary>当前测量项名称 </summary>
        public string Name;
        /// <summary>当前测量项Pin数或区域数 </summary>
        public int PinNum;
        /// <summary>当前测量项在数据显示表格中的行索引 </summary>
        public int RowIndex;
        /// <summary>当前测量项在分类统计表格中的列索引 </summary>
        public int ColIndex;
        /// <summary>当前测量项对应补偿值表格行索引 </summary>
        public int CompRowIndex;
        /// <summary>当前测量项对应理论值行索引 </summary>
        public int TheoreticalRowIndex;
        /// <summary>当前测量项结果 </summary>
        public bool Result;
        /// <summary>当前测量项对应管控项集合，可以一个测量项对应多种管控值 </summary>
        public List<DataThreshold> ThresholdColIndexs;
        /// <summary>当前行测量数据 </summary>
        public DataResult[] DataCells;

        /// <summary>
        /// 此测量项数据行构造函数
        /// </summary>
        /// <param name="name">测量项名称，用于写入Ecxcel</param>
        /// <param name="pinNum">当前测量项Pin数或区域数</param>
        /// <param name="rowIndex">当前测量项在数据显示表格中的行索引</param>
        /// <param name="colIndex">当前测量项在分类统计表格中的列索引</param>
        /// <param name="compRowIndex">当前测量项对应补偿值表格行索引，不存在则指定-1</param>
        /// <param name="thresholdColIndexs">当前测量项对应管控项集合，可以一个测量项对应多种管控值，如果不需要管控可设置为null。</param>
        /// <param name="theoreticalRowIndex">当前测量项对应理论值行索引，不存在则不用指定</param>
        public DataRow(string name, int pinNum, int rowIndex, int colIndex, int compRowIndex, List<DataThreshold> thresholdColIndexs, int theoreticalRowIndex = -1)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PinNum = pinNum;
            RowIndex = rowIndex;
            ColIndex = colIndex;
            CompRowIndex = compRowIndex;
            TheoreticalRowIndex = theoreticalRowIndex;
            Result = false;
            ThresholdColIndexs = thresholdColIndexs;
            DataCells = new DataResult[PinNum];
        }

        /// <summary>
        /// 此测量项数据行构造函数
        /// </summary>
        /// <param name="name">测量项名称，用于写入Ecxcel</param>
        /// <param name="pinNum">当前测量项Pin数或区域数</param>
        public DataRow(string name, int pinNum)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PinNum = pinNum;
            RowIndex = -1;
            ColIndex = -1;
            CompRowIndex = -1;
            TheoreticalRowIndex = -1;
            Result = false;
            ThresholdColIndexs = null;
            DataCells = new DataResult[PinNum];
        }

        /// <summary>
        /// 只读属性：获取本数据行数据列数。
        /// </summary>
        public int CellLength => DataCells.Length;

        /// <summary>
        /// 根据Pin索引获取本数据行指定列的测量结果
        /// </summary>
        /// <param name="pinIndex">Pin索引或区域索引</param>
        /// <returns></returns>
        public DataResult this[int pinIndex] => DataCells[pinIndex];

        /// <summary>
        /// 设置统计结果，将其设置为true。
        /// </summary>
        public void Set()
        {
            Result = true;
        }

        /// <summary>
        /// 复位统计结果，将其设置为false。
        /// </summary>
        public void Reset()
        {
            Result = false;
        }

        /// <summary>
        /// 查找当前测量项当前Pin对应的管控值列索引，返回true表示已找到，返回false表示未找到。
        /// </summary>
        /// <param name="acutalPinIndex">当前Pin实际索引</param>
        /// <param name="thresholdIndex">输出找到的管控值表格列索引，如果没找到则返回0</param>
        /// <returns></returns>
        public bool FindThresholdIndex(int acutalPinIndex, out int thresholdIndex)
        {
            bool result = false;
            thresholdIndex = 0;
            if (ThresholdColIndexs.Count == 1)
            {
                thresholdIndex = ThresholdColIndexs[0].ColIndex;
                result = true;
            }
            else if (ThresholdColIndexs.Count > 1)
            {
                for (int index = 0; index < ThresholdColIndexs.Count; index++)
                {
                    if ((index + 1) == ThresholdColIndexs.Count)
                    {
                        thresholdIndex = ThresholdColIndexs[index].ColIndex;
                        result = true;
                        break;
                    }
                    else if (acutalPinIndex >= ThresholdColIndexs[index].StartPinIndex &&
                        acutalPinIndex < ThresholdColIndexs[index + 1].StartPinIndex)
                    {
                        thresholdIndex = ThresholdColIndexs[index].ColIndex;
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 测量数据更新，每个Pin每个卡尺结果都传递到这里更新。
        /// </summary>
        /// <param name="pinIndex">当前测量Pin或区域实际Pin索引</param>
        /// <param name="dataResult">当前测量数据结果</param>
        public void UpdateResult(int pinIndex, DataResult dataResult)
        {
            DataCells[pinIndex] = dataResult;
            if (!dataResult.Result) Result = false;
        }
    }

    /// <summary>
    /// 结构体：数据管控项
    /// </summary>
    public struct DataThreshold
    {
        /// <summary>此类管控起始Pin索引 </summary>
        public int StartPinIndex;
        /// <summary>此类管控值表格列索引 </summary>
        public int ColIndex;
    }

    /// <summary>
    /// 结构体：结果数据单元
    /// </summary>
    public struct DataResult
    {
        /// <summary>检测数据 </summary>
        public double Data;
        /// <summary>检测结果 </summary>
        public bool Result;
        /// <summary>是否将测量结果写入单元格，如果为true，那么对应的单元格为空白 </summary> 
        public bool SkipCell;

        /// <summary>
        /// 只读属性：数据是否不等于999，是则返回true，否则返回false。
        /// </summary>
        public bool IsNot999 { get => Data != 999; }

        /// <summary>填充结果数据，如果使用默认值999，那么data=999,result=false,skipcell=false;
        /// 如果value为0,则data=0,result=true,skipcell=false；
        /// 如果value为-1,则data=-1,result=true,skipcell=true，对应的单元格留白</summary>
        public void Fill(int value = 999)
        {
            switch (value)
            {
                case 999:
                    Result = false;
                    SkipCell = false;
                    break;
                case 0:
                    Result = true;
                    SkipCell = false;
                    break;
                case -1:
                    Result = true;
                    SkipCell = true;
                    break;
            }
            Data = value;
        }

      
    }

    /// <summary>
    /// 产品构成类，如果有不在此构成中的其他属性，可继承此类实现自己的产品构成类。
    /// </summary>
    public class ProductMix : IProducutProperty
    {
        /// <summary>只读属性：相机拼图数组</summary>
        public int[] CamStitchNums { set; get; }

        /// <summary>只读属性：上排第一类Pin数</summary>
        public int FirstPinNum { private set; get; }

        /// <summary>只读属性：上排第二类Pin数</summary>
        public int SecondPinNum { private set; get; }

        /// <summary>只读属性：上排第三类Pin数</summary>
        public int ThirdPinNum { private set; get; }

        /// <summary>只读属性：上排第四类Pin数</summary>
        public int FourthPinNum { private set; get; }

        /// <summary>只读属性：下排第一类Pin数</summary>
        public int BottomFirstPinNum { private set; get; }

        /// <summary>只读属性：下排第二类Pin数</summary>
        public int BottomSecondPinNum { private set; get; }

        /// <summary>只读属性：下排第三类Pin数</summary>
        public int BottomThirdPinNum { private set; get; }

        /// <summary>只读属性：下排第四类Pin数</summary>
        public int BottomFourthPinNum { private set; get; }

        /// <summary>只读属性：上排突变序号集合数组，数组的每个元素是该相机的上排突变Pin数索引集合</summary>
        public List<int>[] BreakIndexs { set; get; }

        /// <summary>只读属性：下排突变序号集合数组，数组的每个元素是该相机的下排突变Pin数索引集合</summary>
        public List<int>[] BottomBreakIndexs { set; get; }

        /// <summary>只读属性：玻珞针Pin数</summary>
        public int PadNum { set; get; }

        /// <summary>只读属性：是否测量弹针陷入深度</summary>
        public bool CheckXrsd { set; get; }

        /// <summary>只读属性：弹针拼接方法,常规拼接方式为false，先拼接上下排再由上下排合同最后图像为true</summary>
        public bool TanZStitch { set; get; }

        /// <summary>只读属性：上排第二段Pin起始索引 </summary>
        public int SecondStartIndex { get => FirstPinNum; }

        /// <summary>只读属性：上排第三段Pin起始索引 </summary>
        public int ThirdStartIndex { get => FirstPinNum + SecondPinNum; }

        /// <summary>只读属性：上排第四段Pin起始索引 </summary>
        public int FourthStartIndex { get => FirstPinNum + SecondPinNum + ThirdPinNum; }

        /// <summary>只读属性：下排第二段Pin起始索引 </summary>
        public int BottomSecondStartIndex { get => BottomFirstPinNum; }

        /// <summary>只读属性：下排第三段Pin起始索引 </summary>
        public int BottomThirdStartIndex { get => BottomFirstPinNum + BottomSecondPinNum; }

        /// <summary>只读属性：下排第四段Pin起始索引 </summary>
        public int BottomFourthStartIndex { get => BottomFirstPinNum + BottomSecondPinNum + BottomThirdPinNum; }

        /// <summary>属性：是否显示金针露头0.08尺寸。 </summary>
        public bool Show008JinZPin { set; get; }

        /// <summary> 只读属性：获取需测量总Pin数，返回下上排之中最多的Pin数。</summary>
        public int TotalPinNum
        {
            get
            {
                int upTotalPinNum = FirstPinNum + SecondPinNum + ThirdPinNum + FourthPinNum;
                int bottomTotalPinNum = BottomFirstPinNum + BottomSecondPinNum + BottomThirdPinNum + BottomFourthPinNum;
                return upTotalPinNum > bottomTotalPinNum ? upTotalPinNum : bottomTotalPinNum;
            }
        }

        /// <summary> 只读属性：返回所有Pin类别中最多的Pin数。</summary>
        public int MaxPinNum
        {
            get
            {
                int topMax = 0;
                topMax = topMax > FirstPinNum ? topMax : FirstPinNum;
                topMax = topMax > SecondPinNum ? topMax : SecondPinNum;
                topMax = topMax > ThirdPinNum ? topMax : ThirdPinNum;
                topMax = topMax > FourthPinNum ? topMax : FourthPinNum;

                int bottomMax = 0;
                bottomMax = bottomMax > BottomFirstPinNum ? bottomMax : BottomFirstPinNum;
                bottomMax = bottomMax > BottomSecondPinNum ? bottomMax : BottomSecondPinNum;
                bottomMax = bottomMax > BottomThirdPinNum ? bottomMax : BottomThirdPinNum;
                bottomMax = bottomMax > BottomFourthPinNum ? bottomMax : BottomFourthPinNum;

                return topMax > bottomMax ? topMax : bottomMax;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cameraNum">相机个数</param>
        public ProductMix(int cameraNum)
        {
            CamStitchNums = new int[cameraNum];
            FirstPinNum = 0;
            SecondPinNum = 0;
            ThirdPinNum = 0;
            FourthPinNum = 0;
            BottomFirstPinNum = 0;
            BottomSecondPinNum = 0;
            BottomThirdPinNum = 0;
            BottomFourthPinNum = 0;
            BreakIndexs = new List<int>[cameraNum];
            for (int index = 0; index < BreakIndexs.Length; index++)
            {
                BreakIndexs[index] = new List<int>();
            }
            BottomBreakIndexs = new List<int>[cameraNum];
            for (int index = 0; index < BottomBreakIndexs.Length; index++)
            {
                BottomBreakIndexs[index] = new List<int>();
            }
            PadNum = 2;
            CheckXrsd = true;
            TanZStitch = false;
            Show008JinZPin = true;
        }

        /// <summary>
        /// 索引器：设置上排或下排Pin数
        /// </summary>
        /// <param name="pinSection">要设置哪段Pin数</param>
        /// <param name="wetherBottom">要设置上排还是下排Pin数，上排指定false，下排指定true。如果上下排Pin数相等，则不用指定本参数，使用默认值即可。</param>
        /// <returns></returns>
        public int this[int pinSection, bool wetherBottom = false]
        {
            set
            {
                //下排
                if (wetherBottom)
                {
                    switch (pinSection)
                    {
                        case 0:
                            BottomFirstPinNum = value;
                            break;
                        case 1:
                            BottomSecondPinNum = value;
                            break;
                        case 2:
                            BottomThirdPinNum = value;
                            break;
                        case 3:
                            BottomFourthPinNum = value;
                            break;
                    }
                }
                //上排
                else
                {
                    switch (pinSection)
                    {
                        case 0:
                            FirstPinNum = value;
                            break;
                        case 1:
                            SecondPinNum = value;
                            break;
                        case 2:
                            ThirdPinNum = value;
                            break;
                        case 3:
                            FourthPinNum = value;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 索引器：按相机枚举获取该相机Pin间距突变Pin索引集合。
        /// </summary>
        /// <param name="cameraName">相机名称枚举</param>
        /// <param name="wetherBottom">要设置上排还是下排Pin数，上排指定false，下排指定true。如果上下排Pin数相等，则不用指定本参数，使用默认值即可。</param>
        /// <returns></returns>
        public List<int> this[CameraName cameraName, bool wetherBottom = false]
        {
            get
            {
                int camIndex = (int)cameraName - 1;
                List<int> currentBreakIndexs = null;
                if (wetherBottom)
                {
                    if (BottomBreakIndexs != null)
                        currentBreakIndexs = BottomBreakIndexs[camIndex];
                }
                else
                {
                    if (BreakIndexs != null)
                        currentBreakIndexs = BreakIndexs[camIndex];
                }
                return currentBreakIndexs;
            }
        }

        /// <summary>只读属性：最大拼图数 </summary>
        public uint MaxStitchNum
        {
            get
            {
                uint maxNum = 0;
                if (CamStitchNums != null)
                {
                    foreach (uint item in CamStitchNums)
                    {
                        maxNum = maxNum > item ? maxNum : item;
                    }
                }
                return maxNum;
            }
        }

        /// <summary>
        /// 判断每个相机下排Pin间距突变数是否指定，如果未指定，则将该相机上排Pin间距突变数传递给下排。
        /// </summary>
        public void CheckWetherBottomBreakIndexAssigned()
        {
            try
            {
                //检查所有相机上排Pin间距突变集合数组，如果该相机所有突变数为0，则将该相机对应的突变集合设置为null
                if (BreakIndexs == null)
                    return;
                //遍历所有相机
                for (int camIndex = 0; camIndex < BreakIndexs.Length; camIndex++)
                {
                    //如果该相机上排所有突变数未设置，则设置该相机上排突变集合为null
                    if (BreakIndexs[camIndex].Count == 0)
                        BreakIndexs[camIndex] = null;
                }

                if (BottomBreakIndexs == null)
                {
                    BottomBreakIndexs = BreakIndexs;
                    return;
                }
                //遍历所有相机下排突变数组
                for (int camIndex = 0; camIndex < BottomBreakIndexs.Length; camIndex++)
                {
                    //如果该相机下排突变集合为null，则将该相机上排突变集合赋给下排
                    if (BottomBreakIndexs[camIndex] == null)
                    {
                        BottomBreakIndexs[camIndex] = BreakIndexs[camIndex];
                        continue;
                    }
                    //如果该相机下排所有突变数未设置，则设置该相机下排突变集合为null
                    if (BottomBreakIndexs[camIndex].Count == 0)
                        BottomBreakIndexs[camIndex] = BreakIndexs[camIndex];
                }
            }
            catch (System.Exception ex)
            {
                GlobleModule.ShowException(ex);
            }
        }
    }

    /// <summary>
    /// 接口：产品属性必须实现的定义。
    /// </summary>
    public interface IProducutProperty
    {
        /// <summary>只读属性：相机拼图数组。</summary>
        int[] CamStitchNums { set; get; }

        /// <summary>只读属性：上排第一类Pin数</summary>
        int FirstPinNum { get; }

        /// <summary>只读属性：上排第二类Pin数</summary>
        int SecondPinNum { get; }

        /// <summary>只读属性：上排第三类Pin数</summary>
        int ThirdPinNum { get; }

        /// <summary>只读属性：上排第四类Pin数</summary>
        int FourthPinNum { get; }

        /// <summary>只读属性：下排第一类Pin数</summary>
        int BottomFirstPinNum { get; }

        /// <summary>只读属性：下排第二类Pin数</summary>
        int BottomSecondPinNum { get; }

        /// <summary>只读属性：下排第三类Pin数</summary>
        int BottomThirdPinNum { get; }

        /// <summary>只读属性：下排第四类Pin数</summary>
        int BottomFourthPinNum { get; }

        /// <summary> 只读属性：获取需测量总Pin数，返回下上排之中最多的Pin数。</summary>
        int TotalPinNum { get; }

        /// <summary>只读属性：玻珞针Pin数</summary>
        int PadNum { set; get; }

        /// <summary>属性：是否显示金针露头0.08尺寸。 </summary>
        bool Show008JinZPin { get; }

        /// <summary>只读属性：上排突变序号集合数组，数组的每个元素是该相机的上排突变Pin数索引集合</summary>
        List<int>[] BreakIndexs { set; get; }

        /// <summary>只读属性：下排突变序号集合数组，数组的每个元素是该相机的下排突变Pin数索引集合</summary>
        List<int>[] BottomBreakIndexs { set; get; }

        /// <summary>只读属性：上排第二段Pin起始索引 </summary>
        int SecondStartIndex { get; }

        /// <summary>只读属性：上排第三段Pin起始索引 </summary>
        int ThirdStartIndex { get; }

        /// <summary>只读属性：上排第四段Pin起始索引 </summary>
        int FourthStartIndex { get; }

        /// <summary>只读属性：下排第二段Pin起始索引 </summary>
        int BottomSecondStartIndex { get; }

        /// <summary>只读属性：下排第三段Pin起始索引 </summary>
        int BottomThirdStartIndex { get; }

        /// <summary>只读属性：下排第四段Pin起始索引 </summary>
        int BottomFourthStartIndex { get; }
    }

    /// <summary>
    /// 枚举：2D补偿值表格行首
    /// </summary>
    public enum CompRowHeader
    {
        //相机1
        X,
        Y,
        角度,
    }

    /// <summary>
    /// 枚举：管控值表格列首
    /// </summary>
    public enum ThresholdColHeader
    {
        //相机1
        X下限,
        X上限,
        Y下限,
        Y上限,
        角度下限,
        角度上限,
    }
}
