/*
 * FILE : MainWindo.xaml.cpp
 * Project: Assignment 2
 * Programmer: Mahmood Al-Zubaidi
 * FIRST VERSION :  September 28/2021
* DESCRIPTION  :  this MainWindow class genrates the functionality fro the notepadd application, by allowing the user to enter text into the work area and save thier work as a file. it also allowes them
* to start a new notepad, but it alerts them to save thier work. it allwes them to open a certain text file and andust it's syntax. it laerts them through a textbox that
* they should save thier work before starting a new notepad or openiong a new one or closing one.
*/


using Notepad;
using System;
using System.Windows.Media.Animation;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Win32;
using System.Windows.Shapes;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;
using System.ComponentModel;
using Google.Apis.Drive.v3.Data;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public new System.Windows.WindowStartupLocation WindowStartupLocation { get; set; }

        private string file_path;
        public MainWindow()
        {

            InitializeComponent();
        }

        // event handler that calls a function
        private void NewNote(object sender, RoutedEventArgs e)
        {
            eraseAllThenSave();

        }

        // event handler that calls a function
        private void OpenFile(object sender, RoutedEventArgs e)
        {
            AccessFile();
        }

        // event handler that calls a function
        private void SaveAsNote(object sender, RoutedEventArgs e)
        {
            showDilogThenSaveFile();
            
        }

        // event handler that calls a function, but first it checks if 
        // the user have written any text.
        private void Window_Closing(object sender, CancelEventArgs e)
        {

            if (textBoxText.Text != "")
            {
                string c = saveBeforeClose();
                if (c == "Cancel")
                {
                    e.Cancel = true;
                }

                e.Cancel = true;
                this.Visibility = Visibility.Hidden;
            }
        }

        // event handler that calls a function, but first it checks if 
        // the user have written any text.
        private void CloseNotepad(object sender, RoutedEventArgs e)
        {
            if(textBoxText.Text != "")
            {

                string c = saveBeforeClose();
                if( c == "Yes")
                {
                    this.Close();
                }
                if(c == "No")
                {
                    this.Close();
                }
            }
        }

        // event handler that calls a function.
        private void AboutNotepad(object sender, RoutedEventArgs e)
        {
            ShowAboutDialog();
        }

        // event handler that counts the number of lines and charcters
        // the user have inputted.
        private void Indicater(object sender, RoutedEventArgs e)
        {
            int line = textBoxText.GetLineIndexFromCharacterIndex(textBoxText.CaretIndex);
            int column = textBoxText.CaretIndex - textBoxText.GetCharacterIndexFromLineIndex(line);
            position.Text = "Ln " + (line + 1) + ", Col " + (column + 1);
        }


        /** Function: showDilogThenSaveFile
        * Description: it displays a dialog and then checks if the result is true
        * which in case it will call the function that saves that file.
        * Parameters: none
        * Returns: none
        */
        public void showDilogThenSaveFile()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt file (*.txt)|*.txt";

            bool? res = saveFileDialog1.ShowDialog();
            if(res != false)
            {
                Save_File(saveFileDialog1.FileName);
                this.Title = saveFileDialog1.SafeFileName;
            }
        }



        /** Function: saveBeforeClose
        * Description: it dsiplays a message to user indicating that they should save thier changes
        * and if they do then it calls the showDilogThenSaveFile function.
        * Parameters: none
        * Returns: yes or no of the user chooses yes or no, otherwise it will be cancel
        */
        public string saveBeforeClose()
        {
            MessageBoxResult messageResult = System.Windows.MessageBox.Show("do you want to save?", "Notepad", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (messageResult == MessageBoxResult.Yes)
            {
                showDilogThenSaveFile();
                return "Yes";
            }
            else if (messageResult == MessageBoxResult.No)
            {
                return "No";
            }
            return "Cancel";
        }



        /** Function: Save_File
        * Description: it takes the inputted text and writes it to the file specified by the file_path
        * Parameters: the file path in which it contains the file path.
        * Returns: none
        */
        public void Save_File(string file_path)
        {
            StreamWriter noteWriter = new StreamWriter(file_path);
            noteWriter.Write(textBoxText.Text);
            noteWriter.Close();

        }



        /** Function: eraseAllThenSave
        * Description: it empties out the work area's text as well as the title and the filepath
        * Parameters: none
        * Returns: none
        */
        public void eraseAllThenSave()
        {
            if(textBoxText.Text != "")
            {

               string save = saveBeforeClose();
                if(save == "Yes" || save == "No")
                {
                    textBoxText.Text = "";
                    this.Title = string.Empty;
                    file_path = "";
                }
            }

        }



        /** Function: AccessFile
        * Description: it checks to see if the inputted text is emtpy or not, if empty the
         * it calss the saveBeforeClose and openUp functions, if not then it calls the openup function
        * Parameters: none
        * Returns: none
        */
        public void AccessFile()
        {
            if(textBoxText.Text != "")
            {
                saveBeforeClose();
                openUp();
            }
            else
            {
                openUp();
            }
        }



        /** Function: openUp
        * Description: it opens up the chosen file by displaying a dialog and then 
        * sets the title, the file's path to the notepad. it reads the content of the chosen
        * file line by line and appends them into the app's workarea. 
        * Parameters: none
        * Returns: none
        */
        public void openUp()
        {
            var dialogOpen = new Microsoft.Win32.OpenFileDialog();
            dialogOpen.Filter = "txt file (*.txt)|*.txt";
            bool? res = dialogOpen.ShowDialog();
            if (res == true)

            {
                this.Title = dialogOpen.SafeFileName;
                file_path = dialogOpen.FileName;
                StreamReader readFile = new StreamReader(file_path);
                StringBuilder builder = new StringBuilder();
                string reader = readFile.ReadLine();
                while (reader != null)
                {
                    builder.Append(reader);
                    builder.Append(Environment.NewLine);
                    reader = readFile.ReadLine();
                }
                readFile.Close();
                textBoxText.Text = builder.ToString();

                
            }

        }



        /** Function: ShowAboutDialog
        * Description: shows the information about the notepad application.
        * Parameters: none
        * Returns: none
        */
        public void ShowAboutDialog()
        {
            System.Windows.MessageBox.Show("this is a notepad application");
        }
    }
}
