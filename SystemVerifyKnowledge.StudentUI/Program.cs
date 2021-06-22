using Database.Result;
using System;
using System.Windows.Forms;
using SystemVerifyKnowledge.ApplicationContainer;
using SystemVerifyKnowledge.Common.Interface;
using SystemVerifyKnowledge.Models;
using SystemVerifyKnowledge.Presenters;

namespace StudentUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static readonly public ApplicationContainer AppContainer = new();
        static readonly public ApplicationContext AppContext = new();
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppContainer
            .RegisterService<IConnection, ProductionConnection>()
            .RegisterService<IQueryResult, QueryResult>()
            .RegisterModel<IChoseTestModel, ChoseTestModel>()
            .RegisterModel<ITestingModel, TestingModel>()
            .RegisterView<IChoseTestView, ChoseTestForm>()
            .RegisterView<ITestingView, TestingForm>()
            .Run<ChoseTestPresenter>();
        }
    }
}
