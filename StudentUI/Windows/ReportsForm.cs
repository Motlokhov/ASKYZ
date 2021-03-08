using CoreLib.Common;
using CoreLib.Main;
using CoreLib.Testing;
using Database.Result;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StudentUI
{
    public partial class ReportsForm : AbstractForm
    {
        private Microsoft.Office.Interop.Word.Application WordApplication;
        private Document WordDoc;
        private Range range;
        private List<User> users = new List<User>();
        private readonly QueryResult _queryResult = new QueryResult(CustomDependencyInjection.DbConnection);

        public ReportsForm()
        {
            InitializeComponent();
            Show();
        }

        private void DocumentsForm_Load(object sender, EventArgs e)
        {
            DateTime[] dates = _queryResult.LoadTestingDates();

            for(int i = 0; i < dates.Length; i++)
                comboBoxTestingDate.Items.Add(dates[i]);
        }

        //очистка listView
        private void ClearItems()
        {
            if( listViewUsers.Items.Count > 0 )
                listViewUsers.Items.Clear();
        }

        private void AddRangeInWord(string _text , int _bold = 0 , WdParagraphAlignment _paragraphAlignment = WdParagraphAlignment.wdAlignParagraphLeft,WdUnderline _underline = WdUnderline.wdUnderlineSingle)
        {
            range.Start = range.End;
            range.Text = _text;
            range.Bold = _bold;
            range.Paragraphs.Alignment = _paragraphAlignment;
            WordDoc.Paragraphs.Add(range);
        }

        private void buttonReport_Click(object sender, EventArgs e) 
        {
            var countItems = users.Count;
            if ( countItems > 0)
            {
                EducationalCenter EC = new EducationalCenter(@"DataOfEC.xml");
                WordApplication = new Microsoft.Office.Interop.Word.Application();
                WordDoc = WordApplication.Documents.Add(Type.Missing, false, WdNewDocumentType.wdNewBlankDocument, true);
                WordDoc.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                WordApplication.Visible = true;
                range = WordDoc.Range(0, 0);    
                range.Select();
                range.Bold = 1;

                for(var i =0 ;i<countItems ;i++ )
                {
                    if( listViewUsers.Items[i].Checked )
                    {
                        var user = users[i];
                        Core.SetProgramGroupID(user.GetProgramGroupID());
                        Core.LoadDirectionName(_queryResult);
                        Core.LoadProgram(_queryResult);
                        WordDoc.Paragraphs.SpaceAfter = 1;
                        WordDoc.Paragraphs.SpaceBefore = 1;
                        AddRangeInWord("Автономная некоммерческая организация" , 1 , WdParagraphAlignment.wdAlignParagraphCenter);
                        AddRangeInWord("Дополнительного профессионального образования " , 1 , WdParagraphAlignment.wdAlignParagraphCenter);
                        AddRangeInWord("Учебный центр " + EC.Name , 1 , WdParagraphAlignment.wdAlignParagraphCenter);
                        AddRangeInWord("Адрес: " + EC.Addres + ", тел." + EC.Phone , 0 , WdParagraphAlignment.wdAlignParagraphCenter);
                        AddRangeInWord("Сайт: " + EC.Site + " E-mail: " + EC.Email , _paragraphAlignment: WdParagraphAlignment.wdAlignParagraphCenter);
                        AddRangeInWord("___________________________________________________________________________" , 0 , WdParagraphAlignment.wdAlignParagraphCenter);
                        AddRangeInWord("Протокол № " , 0 , WdParagraphAlignment.wdAlignParagraphCenter);
                        AddRangeInWord("компьютерного тестирования" , 0 , WdParagraphAlignment.wdAlignParagraphCenter);
                        AddRangeInWord(DateTime.Today.ToString("d") , 0 , WdParagraphAlignment.wdAlignParagraphCenter);
                        AddRangeInWord("" , 0 , WdParagraphAlignment.wdAlignParagraphCenter);
                        AddRangeInWord( Core.ProgramName, 1 , WdParagraphAlignment.wdAlignParagraphCenter);
                        AddRangeInWord("");
                        AddRangeInWord("ФИО " + user.GetName() );
                        AddRangeInWord("Период обучения с " + user.GetDateStart().ToString("d") + " по " + user.GetDateEnd().ToString("d"));
                        AddRangeInWord("Группа " + Core.ProgramNumber);
                        AddRangeInWord("");
                        AddRangeInWord("Результаты:" , 1);
                        AddRangeInWord("Задание 1 (Тестовые вопросы)" , 1);
                        AddRangeInWord("Не правильных ответов " + user.GetResult(0).FalseAnswers);
                        AddRangeInWord("Правильных ответов " + user.GetResult(0).TrueAnswers);
                        AddRangeInWord("Количество набранных баллов -" + user.GetResult(0).Points);
                        AddRangeInWord("");
                        AddRangeInWord("Задание 2 (Тематические вопросы)" , 1);
                        AddRangeInWord("Не правильных ответов " + user.GetResult(1).FalseAnswers);
                        AddRangeInWord("Правильных ответов " + user.GetResult(1).TrueAnswers);
                        AddRangeInWord("Количество набранных баллов -" + user.GetResult(1).Points);
                        AddRangeInWord("");
                        AddRangeInWord("Задание 3 (Практические задачи)" , 1);
                        AddRangeInWord("Не правильных ответов " + user.GetResult(2).FalseAnswers);
                        AddRangeInWord("Правильных ответов " + user.GetResult(2).TrueAnswers);
                        AddRangeInWord("Количество набранных баллов -" + user.GetResult(2).Points);
                        AddRangeInWord("");
                        AddRangeInWord("Итоговое количество набранных баллов - " +
                            ( user.GetResult(0).Points + user.GetResult(1).Points + user.GetResult(2).Points ).ToString() , 1);
                        AddRangeInWord("");
                        AddRangeInWord("Директор: __________________  " + EC.Director);

                        range.Start = range.End;
                        range.InsertBreak(WdBreakType.wdPageBreak);
                        user = null;
                    }
                }   
            }

            range = null;
            WordDoc = null;
            WordApplication = null;
            
        }

        private void comboBoxTestingDate_SelectedIndexChanged(object sender , EventArgs e)
        {
            users.Clear();

            (ulong userID, ulong testingDateId)[] userResult = _queryResult.LoadUsersResultByTestingDate(comboBoxTestingDate.Text);
            for(var i = 0; i < userResult.Length; i++)
            {
                User user = new User(_queryResult, userResult[i].userID);
                user.SetTestingDateID(userResult[i].testingDateId);
                user.LoadResults();
                users.Add(user);

                listViewUsers.Items.Add
                    (
                        new ListViewItem
                        (
                            new string[]
                            {
                                user.GetID().ToString(),
                                user.GetName().ToString(),
                                _queryResult.LoadProgramByProgramGroupId(user.GetProgramGroupID()).Value.number.ToString()
                            }
                        )
                    );
            }
            
        }
    }
}
