﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.DTO;

namespace Interfaces.Services
{
    public interface ILoadFileService
    {
        void SaveProfitStatisticForRange(string filename, List<ReportAllTransactionsDto> reportData, string header, DateTime StDate, DateTime EndDate);
    }
}
