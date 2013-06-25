﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

///Author: Luisa Andre

namespace Gui
{
    /// <summary>
    /// WDllChooser-Logic for user interaction
    /// </summary>
	public partial class WDllChooser : Window
	{
        string xmlPath = null;
        TextBox showXmlPath;
        string selectedFunction = null;

        /// <summary>
        /// constructor
        /// </summary>
		public WDllChooser()
		{
			this.InitializeComponent();
            showXmlPath = path;
            showXmlPath.Height = 22;
		}

        /// <summary>
        /// returns path of chosen file
        /// </summary>
        /// <returns>string</returns>
        public string getXmlPath()
        {
            return xmlPath;
        }

        /// <summary>
        /// returns selected funktion
        /// </summary>
        /// <returns>string</returns>
        public string getSelectedFunction()
        {
            return selectedFunction;
        }

        /// <summary>
        /// logik for "..."-button: opens file-dialog, gets file-path, reads chosen .xml-file 
        /// and sets values of combobox and textbox
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">RoutedEventArgs</param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string[] functions = null;
            Classes.DllChooser chooser = new Classes.DllChooser();
            Classes.FunctionChooser fc = new Classes.FunctionChooser();

            xmlPath = chooser.openFileDialog();

            if (xmlPath == null)
            {
                return;
            }

            if ("".Equals(xmlPath))
            {
                MessageBox.Show("Please select a valid .xml-File");
                return;
            }
            else
            {
                showXmlPath.Text = xmlPath;
                functions = fc.getFunctions(xmlPath);
                if (null == functions)
                {

                    return;
                }
            }


            combobox.Items.Clear();
            
            for (int i = 0; i < functions.Length; i++)
            {
                combobox.Items.Add(functions[i]);
            }
            
        }

        /// <summary>
        /// logik for "ok"-button: opens WAlgorithmSettings-window and closes itself.
        /// maybe it should set some values at WAlgorithmSettings-Object (constructor?)
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventListener</param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(xmlPath))
            {
                MessageBox.Show("Please select a valid .xml-File");
            }else{
                WAlgorithmSettings ws = new WAlgorithmSettings();
                ws.Show();
                this.Close();
            }
            
        }

        /// <summary>
        /// logic of textbox
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">TextChangedEventArgs</param>
        private void path_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// logic for combobox: sets the selected function
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">SelectionChangedEventArgs</param>
        private void combobox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            selectedFunction = combobox.Text;
        }

	}
}