﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCSMS.Model;
using System.ServiceModel;

namespace HCSMS.Service
{
    [ServiceContract]
    public interface IDinningTableService
    {
        [OperationContract]
        Table QueryTable(string tableNumber);
        [OperationContract]
        List<Table> QueryTableList(QueryCriteria condition);
        [OperationContract]
        List<Table> QueryAvailableTable();
        [OperationContract]
        List<Table> GetTable(DateTime date);

        [OperationContract]
        void UseTable(Dictionary<Table,DinningTable> tables);
        [OperationContract]
        void ChangeTable(string oldTableNumber, string newTableNumber);
     

    }
}
