using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Review
{
    internal class Optimize4
    {

        internal static void Execute(MI request)
        {
            object MDO = null;
            try
            {
                MDO = OperationsWebService.MessageDownload(request);
            }
            catch
            {
                try
                {
                    MDO = OperationsWebService.MessageDownload(request);
                }
                catch
                {
                    try
                    {
                        MDO = OperationsWebService.MessageDownload(request);
                    }
                    catch
                    {
                        try
                        {
                            MDO = OperationsWebService.MessageDownload(request);
                        }
                        catch
                        {
                            try
                            {
                                MDO = OperationsWebService.MessageDownload(request);
                            }
                            catch (Exception ex)
                            {
                                // 5 retries, ok now log and deal with the error.
                            }
                        }
                    }
                }
            }
        }
    }

    internal class MI
    {
    }

    internal class OperationsWebService
    {
        internal static object MessageDownload(MI mI)
        {
            throw new NotImplementedException();
        }
    }
}
