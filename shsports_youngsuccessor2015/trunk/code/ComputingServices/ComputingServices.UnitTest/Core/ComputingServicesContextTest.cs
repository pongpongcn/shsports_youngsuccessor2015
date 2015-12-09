using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Data.Entity;
using ComputingServices.Core.Infrastructure.Persistence;
using ComputingServices.Core.Domain.Models.PersonalityTest;
using ComputingServices.Core.Domain.Models.CertainSportAbilityTest;
using System.Collections.Generic;
using ComputingServices.Core.Domain.Models.Shared;

namespace ComputingServices.UnitTest.Core
{
    [TestClass]
    public class ComputingServicesContextTest
    {
        /// <summary>
        /// 测试项目
        /// </summary>
        [TestMethod]
        public void TestAddCertainSportAbilityTestEvaluationCriteriaSport()
        {
            string sportCode = "sport_for_test";

            CertainSportAbilityTestEvaluationCriteriaSport sport = new CertainSportAbilityTestEvaluationCriteriaSport(sportCode, "花样游泳");

            sport.Parameters.Add(new CertainSportAbilityTestEvaluationCriteriaSportParameter("优秀", 90, null, null, null));
            sport.Parameters.Add(new CertainSportAbilityTestEvaluationCriteriaSportParameter("合格", 60, null, null, null));

            List<CertainSportAbilityTestEvaluationCriteriaSubSport> subSportList = new List<CertainSportAbilityTestEvaluationCriteriaSubSport>();
            List<CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet> subSportParametersSetList = new List<CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet>();

            {
                CertainSportAbilityTestEvaluationCriteriaSubSport subSport = new CertainSportAbilityTestEvaluationCriteriaSubSport("800m", "800米跑", "秒", CertainSportAbilityTestDataType.TimeSpan, CertainSportAbilityTestComparePattern.LessThanOrEqual, sport);

                subSportList.Add(subSport);

                {
                    CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet subSportParametersSet = new CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet(1, 100, Gender.Female, subSport);

                    subSportParametersSet.Parameters.Add(new CertainSportAbilityTestEvaluationCriteriaSubSportParameter("4:20", 3, "及格"));
                    subSportParametersSet.Parameters.Add(new CertainSportAbilityTestEvaluationCriteriaSubSportParameter("4:10", 4, "良好"));
                    subSportParametersSet.Parameters.Add(new CertainSportAbilityTestEvaluationCriteriaSubSportParameter("4:00", 5, "优秀"));

                    subSportParametersSetList.Add(subSportParametersSet);
                }
            }

            {
                CertainSportAbilityTestEvaluationCriteriaSubSport subSport = new CertainSportAbilityTestEvaluationCriteriaSubSport("NeckLength", "颈长", "厘米", CertainSportAbilityTestDataType.Integer, CertainSportAbilityTestComparePattern.GreaterThanOrEqual, sport);

                subSportList.Add(subSport);

                {
                    CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet subSportParametersSet = new CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet(8, 8, null, subSport);

                    subSportParametersSet.Parameters.Add(new CertainSportAbilityTestEvaluationCriteriaSubSportParameter("11", 3, "及格"));
                    subSportParametersSet.Parameters.Add(new CertainSportAbilityTestEvaluationCriteriaSubSportParameter("13", 5, "优秀"));

                    subSportParametersSetList.Add(subSportParametersSet);
                }
                {
                    CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet subSportParametersSet = new CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet(9, 9, null, subSport);

                    subSportParametersSet.Parameters.Add(new CertainSportAbilityTestEvaluationCriteriaSubSportParameter("12", 3, "及格"));
                    subSportParametersSet.Parameters.Add(new CertainSportAbilityTestEvaluationCriteriaSubSportParameter("15", 5, "优秀"));

                    subSportParametersSetList.Add(subSportParametersSet);
                }
                {
                    CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet subSportParametersSet = new CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet(10, 10, null, subSport);

                    subSportParametersSet.Parameters.Add(new CertainSportAbilityTestEvaluationCriteriaSubSportParameter("14", 3, "及格"));
                    subSportParametersSet.Parameters.Add(new CertainSportAbilityTestEvaluationCriteriaSubSportParameter("17", 5, "优秀"));

                    subSportParametersSetList.Add(subSportParametersSet);
                }
                {
                    CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet subSportParametersSet = new CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet(11, 12, null, subSport);

                    subSportParametersSet.Parameters.Add(new CertainSportAbilityTestEvaluationCriteriaSubSportParameter("16", 3, "及格"));
                    subSportParametersSet.Parameters.Add(new CertainSportAbilityTestEvaluationCriteriaSubSportParameter("19", 5, "优秀"));

                    subSportParametersSetList.Add(subSportParametersSet);
                }
            }

            {
                CertainSportAbilityTestEvaluationCriteriaSubSport subSport = new CertainSportAbilityTestEvaluationCriteriaSubSport("Expressiveness", "表现力", null, CertainSportAbilityTestDataType.Characters, CertainSportAbilityTestComparePattern.Equal, sport);

                subSportList.Add(subSport);

                {
                    CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet subSportParametersSet = new CertainSportAbilityTestEvaluationCriteriaSubSportParametersSet(8, 12, null, subSport);

                    subSportParametersSet.Parameters.Add(new CertainSportAbilityTestEvaluationCriteriaSubSportParameter("仅能表达出主题", 3, "及格"));
                    subSportParametersSet.Parameters.Add(new CertainSportAbilityTestEvaluationCriteriaSubSportParameter("具有较强的感染力", 5, "优秀"));

                    subSportParametersSetList.Add(subSportParametersSet);
                }
            }

            using (var context = new ComputingServicesContext())
            {
                var existsSport = context.CertainSportAbilityTestEvaluationCriteriaSports.SingleOrDefault(item => item.Code == sportCode);
                if (existsSport != null)
                {
                    context.CertainSportAbilityTestEvaluationCriteriaSports.Remove(existsSport);
                }

                context.CertainSportAbilityTestEvaluationCriteriaSports.Add(sport);
                context.CertainSportAbilityTestEvaluationCriteriaSubSports.AddRange(subSportList);
                context.CertainSportAbilityTestEvaluationCriteriaSubSportParametersSets.AddRange(subSportParametersSetList);
                context.SaveChanges();
            }
        }
    }
}
