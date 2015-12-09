using ComputingServices.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ComputingServices.App
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IComputingService”。
    [ServiceContract(Name = "ComputingService", Namespace = "http://wicresoft.com/shsports_youngsuccessor2015")]
    public interface IComputingService
    {
        /// <summary>
        /// 个性测试计算阶段1-2，根据原始答题结果获得各因素标准分。
        /// </summary>
        /// <param name="paperResults">原始答题结果</param>
        /// <returns>因素标准分</returns>
        [OperationContract]
        PersonalityTestElementStandardResult[] GetPersonalityTestElementStandardResults(PersonalityTestPaperResult[] paperResults);

        /// <summary>
        /// 个性测试计算阶段3，根据各因素标准分获得4种次级人格因素和4种特殊因素的分数。
        /// </summary>
        /// <param name="standardResults">因素标准分</param>
        /// <returns>因素综合得分</returns>
        [OperationContract]
        PersonalityTestComplexResult[] GetPersonalityTestComplexResults(PersonalityTestElementStandardResult[] standardResults);

        /// <summary>
        /// 认知测试计算阶段1-3，根据原始答题结果获得IQ值与类别
        /// </summary>
        /// <param name="paperResults">原始答题结果</param>
        /// <returns>IQ值与类别</returns>
        [OperationContract]
        IQTestStandardResult[] GetIQTestStandardResults(IQTestPaperResult[] paperResults);

        /// <summary>
        /// 获取某个专项测试的小项分数及分数总和（大项分数）。
        /// </summary>
        /// <param name="originalResults">原始成绩</param>
        /// <returns>小项及大项分数</returns>
        [OperationContract]
        CertainSportAbilityTestStandardResult[] GetCertainSportAbilityTestStandardResults(CertainSportAbilityTestOriginalResult[] originalResults);
    }
}
