﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// Your custom recording code should go in this file.
// The designer will only add methods to this file, so your custom code won't be overwritten.
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

// -- Add the Excel COM reference in:
using Microsoft.Office.Interop.Excel;

namespace dataTableWrite
{
    public partial class Recording1
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
            // Your recording specific initialization code goes here.
        }

        public void writedata()
        {
        	//-------------------------
        	// Excel example - remember to add the micorosft.interop.excel reference to the project!
        	//-------------------------
        	//String xlPath = @"C:\Users\tom\Documents\Ranorex\RanorexStudio Projects\dataTableWrite\dataTableWrite\Data\data.xlsx";  
        	// -- or a relative path to from the bin/debug folder:
        	String xlPath = TestSuite.WorkingDirectory + @"\..\..\Data\data.xlsx";
        	
			Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();  
			Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Open(xlPath);  
			Microsoft.Office.Interop.Excel.Worksheet xlSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlBook.Worksheets["Sheet1"];  
			
			xlApp.DisplayAlerts = false; 
			
			//Excel.Range xlrange = (Excel.Range)xlSheet.Cells[2,2];
			//int[] intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };  
			//Range rng = xlApp.get_Range("A1", "J1");  
			//rng.Value = intArray;  
			
			// -- Find out the current row we are on from Ranorex & write a value to column 3
			// -- add a row as row 1 in excel is the ranorex column headings!
			xlSheet.Cells[TestSuite.CurrentTestContainer.DataContext.CurrentRowIndex + 1, 3] = "hello";
			// -- you can also use cell references such as 'A2'
			//xlSheet.Cells(C1)="hello";
			xlBook.Save();  
			xlBook.Close(); 
        	
			// I was hoping this would stop the message you get to reload the data after a test run as the 
			// spreadsheet has changed as we wrote to it, but doesn't seem to work:
			//TestSuite.CurrentTestContainer.DataContext.ReloadData();
        }

    }
}
