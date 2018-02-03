
using System;

namespace Client.TMRI
{
    /// <summary>
    /// TMRIException 
    /// </summary>
    class TMRIException : Exception
    {
        /// <summary>
        /// constructor with exception type as parameter
        /// </summary>
        /// <param name="type">exception type </param>
        public TMRIException(TypeEnum type) : this(type, "", "")
        {
        }//end of constructor

        /// <summary>
        /// constructor with exception type and additional message as parameter
        /// </summary>
        /// <param name="type">exception type </param>
        /// <param name="additionalMessage">additional message</param>
        public TMRIException(TypeEnum type, string additionalMessage) : this(type, additionalMessage, "")
        {
        }//end of constructor

        /// <summary>
        /// constructor with exception type and additional message as parameters
        /// </summary>
        /// <param name="type">exception type</param>
        /// <param name="additionalMessage1">additional message</param>
        /// <param name="additionalMessage2">additional message</param>
        public TMRIException(TypeEnum type, string additionalMessage1, string additionalMessage2) : base($"{__DefaultMessage}: {getMessage(type, additionalMessage1, additionalMessage2)}")
        {
        }//end of constructor

        /// <summary>
        /// enum of exception type
        /// </summary>
        public enum TypeEnum
        {
            ErrorMessage,

            //xml structure error
            SchemaError,

            /// <summary>
            /// unknown interface identity(jkid)
            /// </summary>
            UnknownID,
        }//end of enum

        /// <summary>
        /// Default exception message
        /// </summary>
        static string __DefaultMessage = "TMRI out access interface error";

        /// <summary>
        /// Get exception message according to type and additional messages
        /// </summary>
        /// <param name="type">exception type</param>
        /// <param name="additionalMessage1">additional message</param>
        /// <param name="additionalMessage2">additional message</param>
        /// <returns>exception message</returns>
        static string getMessage(TypeEnum type, string additionalMessage1, string additionalMessage2)
        {
            switch (type)
            {
                case TypeEnum.ErrorMessage:
                    return additionalMessage1 + additionalMessage2;
                case TypeEnum.SchemaError:
                    return $"Xml element -{additionalMessage1}- is expected but -{additionalMessage2}- is found";
                case TypeEnum.UnknownID:
                    return $"Unknown jkid -{additionalMessage1}";
                default:
                    return "";
            }//end of switch
        }//end of method
    }//end of class
}
