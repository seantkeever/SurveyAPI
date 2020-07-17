using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurveyAPI.Models;

namespace SurveyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        //-----------------------------------------
        //-------- Question Table Methods ----------
        //-----------------------------------------

        [HttpPost("InsertQuestion")]
        public ActionResult<string> InsertQuestion([FromBody] System.Text.Json.JsonElement inputData)
        {

            string Description = string.Empty;
            bool AllowYesNo = false;
            bool AllowShortAnswer = false;
            try
            {
                Description = inputData.GetProperty("Description").GetString();
                AllowYesNo = inputData.GetProperty("AllowYesNo").GetBoolean();
                AllowShortAnswer = inputData.GetProperty("AllowShortAnswer").GetBoolean();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Survey InsertQuestion - Invalid parameters detected");
            }

            DataAccess.SurveyAccess dataAccess = new DataAccess.SurveyAccess();
            try
            {
                bool bResult = dataAccess.InsertQuestion(Description, AllowYesNo, AllowShortAnswer);
                if (dataAccess._lastSqlException != null && !string.IsNullOrWhiteSpace(dataAccess._lastSqlException.Message))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, dataAccess._lastSqlException.Message);
                }
                else
                {
                    //Build output
                    Output output = new Output(bResult, null);
                    return Ok(JsonConvert.SerializeObject(output));
                }
            }
            catch(Exception x)
            {
                if (dataAccess._lastSqlException != null && !string.IsNullOrWhiteSpace(dataAccess._lastSqlException.Message))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, dataAccess._lastSqlException.Message);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, x.Message);
                }
            }
        }


        [HttpPost("DeleteQuestion")]
        public ActionResult<string> DeleteQuestion([FromBody] System.Text.Json.JsonElement inputData)
        {
            short QuestionID = 0;
            try
            {
                QuestionID = inputData.GetProperty("QuestionID").GetInt16();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Survey DeleteQuestion - Invalid parameters detected");
            }

            DataAccess.SurveyAccess dataAccess = new DataAccess.SurveyAccess();
            try
            {
                bool bResult = dataAccess.DeleteQuestion(QuestionID);
                if (dataAccess._lastSqlException != null && !string.IsNullOrWhiteSpace(dataAccess._lastSqlException.Message))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, dataAccess._lastSqlException.Message);
                }
                else
                {
                    //Build output
                    Output output = new Output(bResult, null);
                    return Ok(JsonConvert.SerializeObject(output));
                }
            }
            catch (Exception x)
            {
                if (dataAccess._lastSqlException != null && !string.IsNullOrWhiteSpace(dataAccess._lastSqlException.Message))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, dataAccess._lastSqlException.Message);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, x.Message);
                }
            }
        }





        //-----------------------------------------
        //-------- Answer Table Methods ----------
        //-----------------------------------------

        [HttpPost("InsertAnswer")]
        public ActionResult<string> InsertAnswer([FromBody] System.Text.Json.JsonElement inputData)
        {
            short QuestionID = 0;
            bool? YesNo = false;
            string Description = string.Empty;
            try
            {
                QuestionID = inputData.GetProperty("QuestionID").GetInt16();
                YesNo = inputData.GetProperty("YesNo").GetBoolean();
                Description = inputData.GetProperty("Description").GetString();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Survey InsertAnswer - Invalid parameters detected");
            }

            DataAccess.SurveyAccess dataAccess = new DataAccess.SurveyAccess();
            try
            {
                bool bResult = dataAccess.InsertAnswer(QuestionID, YesNo, Description);
                if (dataAccess._lastSqlException != null && !string.IsNullOrWhiteSpace(dataAccess._lastSqlException.Message))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, dataAccess._lastSqlException.Message);
                }
                else
                {
                    //Build output
                    Output output = new Output(bResult, null);
                    return Ok(JsonConvert.SerializeObject(output));
                }
            }
            catch (Exception x)
            {
                if (dataAccess._lastSqlException != null && !string.IsNullOrWhiteSpace(dataAccess._lastSqlException.Message))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, dataAccess._lastSqlException.Message);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, x.Message);
                }
            }
        }


        [HttpPost("DeleteAnswer")]
        public ActionResult<string> DeleteAnswer([FromBody] System.Text.Json.JsonElement inputData)
        {
            short AnswerID = 0;
            try
            {
                AnswerID = inputData.GetProperty("AnswerID").GetInt16();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Survey DeleteAnswer - Invalid parameters detected");
            }

            DataAccess.SurveyAccess dataAccess = new DataAccess.SurveyAccess();
            try
            {
                bool bResult = dataAccess.DeleteAnswer(AnswerID);
                if (dataAccess._lastSqlException != null && !string.IsNullOrWhiteSpace(dataAccess._lastSqlException.Message))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, dataAccess._lastSqlException.Message);
                }
                else
                {
                    //Build output
                    Output output = new Output(bResult, null);
                    return Ok(JsonConvert.SerializeObject(output));
                }
            }
            catch (Exception x)
            {
                if (dataAccess._lastSqlException != null && !string.IsNullOrWhiteSpace(dataAccess._lastSqlException.Message))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, dataAccess._lastSqlException.Message);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, x.Message);
                }
            }
        }
    }
}