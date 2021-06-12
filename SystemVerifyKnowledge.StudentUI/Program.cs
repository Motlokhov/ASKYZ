using Database.Result;
using System;
using System.Windows.Forms;
using SystemVerifyKnowledge.ApplicationController;
using SystemVerifyKnowledge.Common.Interface;
using SystemVerifyKnowledge.Presenters;

namespace StudentUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static public ApplicationController AppController = new();
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppController
            .RegisterService<IConnection, ProductionConnection>()
            .RegisterService<IQueryResult, QueryResult>()
            .RegisterView<IChoseTestView, ChoseTestForm>()
            .RegisterView<ITestingView, TestingForm>()
            .Run<ChoseTestPresenter>();
        }
    }
}
