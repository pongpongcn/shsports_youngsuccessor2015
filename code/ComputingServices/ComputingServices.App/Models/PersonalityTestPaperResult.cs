using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ComputingServices.App.Models
{
    /// <summary>
    /// 个性测试原始答题结果（基于单张问卷）
    /// </summary>
    [DataContract]
    public class PersonalityTestPaperResult
    {
        /// <summary>
        /// 标识是哪套题
        /// </summary>
        [DataMember]
        public string QuestionsSetCode { get; set; }
        /// <summary>
        /// 本问卷中所有题目实际答案
        /// </summary>
        [DataMember]
        public PersonalityTestPaperQuestionAnswer[] QuestionAnswers { get; set; }
        /// <summary>
        /// 进行本问卷测试时，答卷者当时的年龄
        /// </summary>
        [DataMember]
        public int Age { get; set; }
        /// <summary>
        /// 答卷者性别
        /// </summary>
        [DataMember]
        public Gender Gender { get; set; }
        /// <summary>
        /// 关联标识 可为空，便于对接口返回结果的检索（批量调用）。
        /// </summary>
        [DataMember]
        public string RefId { get; set; }
    }

    /// <summary>
    /// 个性测试中某道题的答案
    /// </summary>
    [DataContract]
    public class PersonalityTestPaperQuestionAnswer
    {
        /// <summary>
        /// 问题编号
        /// </summary>
        [DataMember]
        public int QuestionCode { get; set; }
        /// <summary>
        /// 答案 区分大小写，目前均使用大写字母（A、B、C）。
        /// </summary>
        [DataMember]
        public string Answer { get; set; }
    }
}