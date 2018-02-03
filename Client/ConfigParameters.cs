
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using static Client.DBM;

namespace Client
{
    /// <summary>
    /// map to Table CFG_PARAM
    /// </summary>
    static class ConfigParameters
    {
        /// <summary>
        /// constructor with no parameter
        /// </summary>
        static ConfigParameters()
        {
            refresh();
        }//end of constructor

        /// <summary>
        /// refresh all itmes from database
        /// </summary>
        internal static void refresh()
        {
            DataTable table = new DataTable();

            OracleDataAdapter __ParamAdapter = new OracleDataAdapter("select PARAM_NAME,PARAM_VALUE from CFG_PARAM", mDBM.conn);
            new OracleCommandBuilder(__ParamAdapter);
            __ParamAdapter.Fill(table);

            __items.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
                __items.Add(new ConfigParameter(table.Rows[i]["PARAM_NAME"].ToString(), table.Rows[i]["PARAM_VALUE"].ToString()));
        }//end of method

        internal static string getValue(string name)
        {
            for (int i = 0; i < __items.Count; i++)
                if (name == __items[i].Name) return __items[i].Value;
            throw new Exception($"Parameter: {name} not found");
        }//end of mtehod

        internal static void setValue(string name, string value)
        {
            for (int i = 0; i < __items.Count; i++)
                if (name == __items[i].Name)
                {
                    __items[i].Value = value;
                    if (!__Transaction)
                    {
                        string message;
                        if (__items[i].update(out message) < 0) throw new Exception(message);
                    }
                    else
                        __items[i].Modified = true;
                    return;
                }
            throw new Exception($"Parameter: {name} not found");
        }//end of mtehod

        internal static void beginUpdate()
        {
            __Transaction = true;
        }//end of mtehod

        internal static void commitUpdate()
        {
            string message;
            for (int i = 0; i < __items.Count; i++)
                if (__items[i].Modified) if (__items[i].update(out message) < 0) throw new Exception(message);
            __Transaction = false;
        }//end of mtehod

        /// <summary>
        /// whether batch update or single
        /// </summary>
        private static bool __Transaction;

        /// <summary>
        /// list of ConfigParameter(s)
        /// </summary>
        private static List<ConfigParameter> __items = new List<ConfigParameter>();

        /// <summary>
        /// map to a record of Table CFG_PARAM
        /// </summary>
        private class ConfigParameter
        {
            /// <summary>
            /// parameter name, map to PARAM_NAME of Table CFG_PARAM
            /// </summary>
            internal readonly string Name;

            /// <summary>
            /// parameter value, map to PARAM_VALUE of Table CFG_PARAM
            /// </summary>
            internal string Value;

            /// <summary>
            /// value modified and not write back to database
            /// </summary>
            internal bool Modified;

            /// <summary>
            /// constructor with name and value as parameters
            /// </summary>
            /// <param name="name">parameter name, map to PARAM_NAME of Table CFG_PARAM</param>
            /// <param name="value">parameter value, map to PARAM_VALUE of Table CFG_PARAM</param>
            internal ConfigParameter(string name, string value)
            {
                Name = name;
                Value = value;
                Modified = false;
            }//end of constructor

            /// <summary>
            /// update to Table CFG_PARAM
            /// </summary>
            /// <param name="message">output message or StoredProcedure SetParameter</param>
            /// <returns>
            ///     0:  update successfully
            ///     1:  update not needed
            ///     -1: update failed
            /// </returns>
            internal int update(out string message)
            {
                Modified = false;
                return mDBM.SetParameter(out message, Name, Value);
            }//end of method
        }//end of struct
    }//end of class
}
