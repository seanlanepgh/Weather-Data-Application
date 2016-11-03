using System;
using System.Text;
using System.IO;
public class Assessment2
{
	public static void Main( string[] args )
	{	
		//Declare two dimesional arrays
		double [,] originalWS1DataArray = new double [1022,7];// Holds the original data from files for Weather Station 1 
		double [,] tempWS1DataArray = new double [1022,7];// Allows the Weather Station 1  array to be temporary sorted
		double [,] originalWS2DataArray = new double [1022,7];// Holds the original data from files for Weather Station 2
		double [,] tempWS2DataArray = new double [1022,7];// Allows the Weather Station 2  array to be temporary sorted
		int selectedColumn=0;//Holds the selected column that the user has selected to sort or search
		char orderChoice;//Holds the user choice for if they want it ascending or descending order
		bool monthValid =false;//Used to validate user input for the month
		bool orderValid = false;//used to vallidate user input for the sorting order
		bool yearVaild =false;//used to validate user input for the year
		int year = 0;//Stores the year  entered by the user
		string monthChoice = "";// Stores the month entered by the user 
		int columnChoice = 0;//Stores the selected Column the user entered
		bool columnValid =false;//Used to validate the user input for the selected column menu
		bool columnValidExit =false;//Used tp  validate if the user has selected the exit option
		double monthInput= 0;//Store the number equivalent of the month entered by the user
		int WS1NumOfOccurences = 0; // Get the number of occurences and store it .For weather station 1
		int WS2NumOfOccurences = 0; // Get the number of occurences and store it .For weather station 2
		Console.WriteLine(" Weather Data is currently Sorted in the respect to the years and months");
		Console.WriteLine(" MDTMaxmium stands for: Mean Daily Temperature Maximium");
		Console.WriteLine(" MDTMinmium stands for: Mean Daily Temperature Minimium");
		Console.WriteLine("  ");
		//Calls functions that read in the files into two dimesional arrays
		originalWS1DataArray = ReadWS1Files();//Reads in files related to the Weather Station 1 data
		originalWS2DataArray = ReadWS2Files();//Reads in files related to the Weather Station 2 data
		Console.WriteLine(" Weather Station 1 (WS1/Lerwick)");
		//Calls function that would use a for loop to display each of the table columns names
		DisplayColumnNames();
		//Calls function that displays the  weather  station data for Lerwick 
		DisplayWeatherData(originalWS1DataArray);
		//Copies data from the original  weather station 1 array to the temporary weather station 1 array for manipulation
		ResetFileArray(originalWS1DataArray,tempWS1DataArray);
		Console.ReadLine();
		Console.WriteLine("	");
		Console.WriteLine(" Weather Station 2 (WS2/Ross on Wye)");
		DisplayColumnNames();
		//Calls function that displays the  weather  station data for Ross on Wye
		DisplayWeatherData(originalWS2DataArray);
		//Copies data from the original  weather station 2 array to the temporary weather station 2 array for manipulation
		ResetFileArray(originalWS2DataArray,tempWS2DataArray);
		Console.ReadLine();
		//Loops until the user wants to exit the menu
		do{
			//Loops until the user has entered the correct value from the menu
			do{
				columnValid = false;
				//Display the  Select Column Menu to the user
				Console.WriteLine("Select Column To Sort Menu");
				Console.WriteLine("1: Year");
				Console.WriteLine("2: Months");
				Console.WriteLine("3: Mean Daily Temperature Maximium");
				Console.WriteLine("4 :Mean Daily Temperature Minimium");
				Console.WriteLine("5 :Days of Air Frost");
				Console.WriteLine("6 :Total Rainfall");
				Console.WriteLine("7:Total Sunshine duration");
				Console.WriteLine("8: Exit Sorting");
				Console.WriteLine("Enter a number to select a column for sorting  or to exit sorting:");
				//Get the user input for the menu
				string columnInput = Console.ReadLine();
				//Check if  the input is  a integer 
				if (!Int32.TryParse(columnInput, out columnChoice))
				{
					//if not display error message 
					Console.WriteLine("Invalid input, please try again...");
				}
				//Change the selected column based on the user input
				switch (columnChoice)
				{
					case 1:
						selectedColumn = 0;
						columnValid = true;
						columnValidExit = false;
						
					break;
					case 2:
						selectedColumn = 1;
						columnValid = true;
						columnValidExit = false;
					break;
					case 3:
						selectedColumn = 2;
						columnValid = true;
						columnValidExit = false;
					break;
					case 4:
						selectedColumn = 3;
						columnValid = true;
						columnValidExit = false;
					break;
					case 5:
						selectedColumn = 4;
						columnValid = true;
						columnValidExit = false;
					break;
					case 6:
						selectedColumn = 5;
						columnValid = true;
						columnValidExit = false;
					break;
					case 7:
						selectedColumn = 6;
						columnValid = true;
						columnValidExit = false;
					break;
					case 8:
						columnValid = true;
						columnValidExit = true;
					break;
					//if the input doesn't match one of the choice display error message
					default:
						Console.WriteLine("Enter the correct columns");
						columnValid = false;
						columnValidExit = false;
					break;
				}
			}while(columnValid == false);
			
			if(columnValidExit == true ){
				//if the user has selected the option to exit sorting then don't do the sorting 
			}else{
				//if  the has not selected the option to exit then do the sorting 
				do{
					orderValid = false;
					//Gets the user to select ascending or descending order
					Console.WriteLine("Enter  \"a\" for ascending or enter \"d\" for descending order");
					//Get if it is ascending or descending order.
					string  orderInput = Console.ReadLine();
					//Check if it is a char 
					if (!Char.TryParse(orderInput, out orderChoice))
					{
						// if not display error message
						Console.WriteLine("Invalid input, please try again...");
					}
					//Check if the single char is a or d 
					if(orderChoice =='a' || orderChoice =='d'){
						orderValid = true;
					}else{
						orderValid = false;
						// if not display error message
						Console.WriteLine("Invalid input, please try again...");
					}
				}while(orderValid ==false);
				
				//Reset iteration counters for each sorting algorithm
				Sort.quickSortIteration = 0;
				Sort.bubbleSortIteration = 0;
				Sort.insertionSortIteration = 0;
				Sort.mergeSortIteration = 0;
				Sort.heapSortIteration = 0;
				ResetFileArray(originalWS1DataArray,tempWS1DataArray);
				ResetFileArray(originalWS2DataArray,tempWS2DataArray);
				Console.WriteLine("Weather Station 1 (Lerwick) Data");
				DisplayColumnNames();
				/*Here  below , i have  tested each of the different sort algorithms by running them and getting
				their number of iterations.
				After that  i would reset the temporary array for weather station 1 for  the next algorithm.
				*/
				//Calls the Bubble Sort Algorithm function
				Sort.BubbleSort(tempWS1DataArray,selectedColumn,orderChoice);
				//Resets the temporary Array for Weather Station 1
				tempWS1DataArray = ResetFileArray(originalWS1DataArray,tempWS1DataArray);
				//Calls the Insertion Sort Algorithm function
				Sort.InsertionSort(tempWS1DataArray,selectedColumn,orderChoice);
				//Resets the temporary Array for Weather Station 1
				tempWS1DataArray = ResetFileArray(originalWS1DataArray,tempWS1DataArray);
				//Calls the Merge Sort Algorithm function
				Sort.MergeSort(tempWS1DataArray,selectedColumn,orderChoice);
				//Resets the temporary Array for Weather Station 1
				tempWS1DataArray = ResetFileArray(originalWS1DataArray,tempWS1DataArray);
				//Calls the Heap Sort Algorithm function
				Sort.HeapSort(tempWS1DataArray,selectedColumn,orderChoice);
				//Resets the temporary Array for Weather Station 1
				tempWS1DataArray = ResetFileArray(originalWS1DataArray,tempWS1DataArray);
				//Calls the Quick Sort Algorithm function
				//I have decided to use quick Sort as it is the most efficient for sorting this data
				Sort.QuickSort(tempWS1DataArray,selectedColumn,orderChoice);
				//Calls function that displays the now sorted weather  station data for Lerwick 
				DisplayWeatherData(tempWS1DataArray);
				//Displays the testing i have done on each of the algorithms and shows the number of iterations for each one		
				Console.WriteLine("Total number of iternations for Bubble Sort:"+Sort.bubbleSortIteration);
				Console.WriteLine("Total number of iternations for Insertion Sort:"+Sort.insertionSortIteration);
				Console.WriteLine("Total number of iternations for Merge Sort:"+Sort.mergeSortIteration);
				Console.WriteLine("Total number of iternations for Heap Sort:"+Sort.heapSortIteration);
				Console.WriteLine("Total number of iternations for Quick Sort:"+Sort.quickSortIteration);	
				//Gets the Maximium , Medium and Minimium values from the sorts and displays their corresponding values 
				DisplayMaxMinMedian(tempWS1DataArray,selectedColumn,orderChoice);
				Console.ReadLine();
				//Reset iteration counters for each sorting algorithm
				Sort.quickSortIteration = 0;
				Sort.bubbleSortIteration = 0;
				Sort.insertionSortIteration = 0;
				Sort.mergeSortIteration = 0;
				Sort.heapSortIteration = 0;
				Console.WriteLine("Weather Station 2 (Ross On Wye) Data");
				DisplayColumnNames();
				/*Here  below , i have  tested each of the different sort algorithms by running them and getting
				their number of iterations.
				After that  i would reset the temporary array for weather station 2 for  the next algorithm.
				*/
				//Calls the Bubble Sort Algorithm function
				Sort.BubbleSort(tempWS2DataArray,selectedColumn,orderChoice);
				//Resets the temporary Array for Weather Station 2
				tempWS2DataArray = ResetFileArray(originalWS2DataArray,tempWS2DataArray);
				//Calls the Insertion Sort Algorithm function
				Sort.InsertionSort(tempWS2DataArray,selectedColumn,orderChoice);
				//Resets the temporary Array for Weather Station 2
				tempWS2DataArray = ResetFileArray(originalWS2DataArray,tempWS2DataArray);
				//Calls the Merge Sort Algorithm function
				Sort.MergeSort(tempWS2DataArray,selectedColumn,orderChoice);
				//Resets the temporary Array for Weather Station 2
				tempWS2DataArray = ResetFileArray(originalWS2DataArray,tempWS2DataArray);
				//Calls the Heap Sort Algorithm function
				Sort.HeapSort(tempWS2DataArray,selectedColumn,orderChoice);
				//Resets the temporary Array for Weather Station 2
				tempWS2DataArray = ResetFileArray(originalWS2DataArray,tempWS2DataArray);
				//Calls the Quick Sort Algorithm function
				//I have decided to use quick Sort as it is the most efficient for sorting this data
				Sort.QuickSort(tempWS2DataArray,selectedColumn,orderChoice);
				//Calls function that displays the now sorted weather  station data for Ross On Wye
				DisplayWeatherData(tempWS2DataArray);
				//Displays the testing i have done on each of the algorithms and shows the number of iterations for each one		
				Console.WriteLine("Total number of iternations for Bubble Sort:"+Sort.bubbleSortIteration);
				Console.WriteLine("Total number of iternations for Insertion Sort:"+Sort.insertionSortIteration);
				Console.WriteLine("Total number of iternations for Merge Sort:"+Sort.mergeSortIteration);
				Console.WriteLine("Total number of iternations for Heap Sort:"+Sort.heapSortIteration);
				Console.WriteLine("Total number of iternations for Quick Sort:"+Sort.quickSortIteration);	
				DisplayMaxMinMedian(tempWS2DataArray,selectedColumn,orderChoice);
				Console.ReadLine();
			}
		}while (columnValidExit == false);
		Console.ReadLine();
		//Searching Code 
		Console.WriteLine("Searching ");
		Console.WriteLine("Weather Station 1 (Lerwick) Data");
		DisplayColumnNames();
		DisplayWeatherData(originalWS1DataArray);
		Console.ReadLine();
		Console.WriteLine("Weather Station 2 (Ross on Wye) Data");
		DisplayColumnNames();
		DisplayWeatherData(originalWS2DataArray);
		//Loop until the user enters a valid input
		do {
			//Ask user to Search for the Year
			Console.WriteLine("Please Enter A Year to Search  both weather data:");
			//Store the year that was entered by the user
			string  yearInput = Console.ReadLine();
			//Converts the  string to integer 
			if (!Int32.TryParse(yearInput, out year))
			{
				yearVaild = false;
				// if it doesn't convert display error message
				Console.WriteLine("Invalid input, please try again...");
			}else{
				//if  it does convert then it is valid
				yearVaild = true;
			}
		}while(yearVaild == false);
		selectedColumn = 0;//Resets selected column
		//Reset both temporary array for both station data
		ResetFileArray(originalWS1DataArray,tempWS1DataArray);
		ResetFileArray(originalWS2DataArray,tempWS2DataArray);
		Console.WriteLine("	");
		Console.WriteLine("WS1 Search Results");
		//Call recursive binary search function to search weather station 1 data  and then store its found index
		int foundIndex = Searching.BinarySearch_R(year,tempWS1DataArray,0,1022,selectedColumn);
		//Display number of binary search iternations for weather station 1 data 
		Console.WriteLine("WS1:Total number of iternations for binary search:"+Searching.binarySearchIterations);
		//If the binary search doesn't find the data don't do binary search hybrid code and go straight to the linear search
		if (foundIndex != -1)
		{
			//If binary search is successful then display the index the data was found
			Console.WriteLine("The binary search found the data at index: {0}",foundIndex);
			int []yearWS1OccurIndexs = new int [Searching.binaryHybridOccur];//Create an array to store the multiple indexs for multiple occurences of that data for weather station 1 
			Console.WriteLine("As binary search is only effective for searching for  one value, we had to use a linear search or Binary Search Hybrid to find all corresponding values ");
			//Call the  binary search hybrid function to check for multiple occurences of that data for weather station 1 
			yearWS1OccurIndexs = Searching.BinarySearchHybrid(year,tempWS1DataArray,selectedColumn,foundIndex);
			DisplayColumnNames();
			WS1NumOfOccurences = Searching.binaryHybridOccur - Searching.binarySearchIterations; // Get the number of occurences and store it .For weather station 1
			//Displays the results of the binary search hybrid  for weather station 1 
			DisplaySearchResults(tempWS1DataArray, yearWS1OccurIndexs,WS1NumOfOccurences);
			// Display binary search hybrid  iternations  for weather station 1 
			Console.WriteLine("WS1:Total number of iternations for Binary Search Hybrid:"+ Searching.binaryHybridOccur);
		}
		int []yearWS1LinearOccurIndexs = new int [Searching.linearSearchOccur];// Gets the number of occurences of that data in a linear search for weather station 1
		//Call the Linear Search function and  get the indexs of the occurences of the data that the user is searching for 
		yearWS1LinearOccurIndexs = Searching.LinearSearch(year,tempWS1DataArray,foundIndex,selectedColumn);
		//Checks if there is  any results to display
		if (Searching.linearSearchOccur == 0)
		{
			// if not  then display nothing 	
		}else
		{
			// if there are results display the table column names 
			DisplayColumnNames();
		}
		//Displays the results of the linear search  for weather station 1 
		DisplaySearchResults(tempWS1DataArray,yearWS1LinearOccurIndexs,Searching.linearSearchOccur);
		//Display linear search iterations  for weather station 1 
		Console.WriteLine("WS1:Total number of iternations for Linear (Sequential) Search :"+Searching.linearSearchIteration);
		Console.ReadLine();
		Console.WriteLine("	");
		//Reset iteration and occurence counters for each searching algorithm
		Searching.binarySearchIterations = 0;
		Searching.binaryHybridOccur = 0;
		Searching.linearSearchIteration = 0 ;
		Searching.linearSearchOccur = 0;
		Console.WriteLine("WS2 Search Results");
		//Call recursive binary search function to search weather station 2 data  and then store its found index
		foundIndex = Searching.BinarySearch_R(year,tempWS2DataArray,0,1022,selectedColumn);
		//Display number of binary search iternations for weather station 2 data 
		Console.WriteLine("WS2:Total number of iternations for Binary  Search:"+Searching.binarySearchIterations);
		//If the binary search doesn't find the data don't do binary search hybrid code and go straight to the linear search
		if (foundIndex != -1)
		{
			int []yearWS2OccurIndexs= new int [Searching.binaryHybridOccur];//Create an array to store the multiple indexs for multiple occurences of that data for weather station 1 
			Console.WriteLine("As binary search is only effective for searching for  one value, we had to use a linear search or Binary Search Hybrid to find all corresponding values ");
			//Call the  binary search hybrid function to check for multiple occurences of that data for weather station 1 
			yearWS2OccurIndexs = Searching.BinarySearchHybrid(year,tempWS2DataArray,selectedColumn,foundIndex);
			DisplayColumnNames();
			WS2NumOfOccurences = Searching.binaryHybridOccur - Searching.binarySearchIterations; // Get the number of occurences and store it. For weather station 2 
			//Displays the results of the binary search hybrid  for weather station 2
			DisplaySearchResults(tempWS2DataArray,yearWS2OccurIndexs,WS2NumOfOccurences);
			// Display binary search hybrid  iternations  for weather station 2
			Console.WriteLine("WS2:Total number of iternations for Binary  Search Hybrid:"+ Searching.binaryHybridOccur);
		}
		int []yearWS2LinearOccurIndexs = new int [Searching.linearSearchOccur];// Gets the number of occurences of that data in a linear search for weather station 2
		//Call the Linear Search function and  get the indexs of the occurences of the data that the user is searching for 
		yearWS2LinearOccurIndexs = Searching.LinearSearch(year,tempWS2DataArray,foundIndex,selectedColumn);
		//Checks if there  is any results to display
		if (Searching.linearSearchOccur== 0)
		{
			// if not  then display nothing 	
		}else
		{
			// if there are results display the table column names 
			DisplayColumnNames();
		}
		//Displays the results of the linear search  for weather station 2 
		DisplaySearchResults(tempWS2DataArray,yearWS2LinearOccurIndexs,Searching.linearSearchOccur);
		//Display linear search iterations  for weather station 2
		Console.WriteLine("WS2:Total number of iternations for Linear (Sequential) Search :"+Searching.linearSearchIteration);
		Console.WriteLine("	");
		//Loop until month input is valid
		do{
			//Ask user to enter a month 
			Console.WriteLine("Please Enter A Month:");
			monthChoice = Console.ReadLine();// Store the month that the user has entered 
			//Check if  the string entered is null
			if(string.IsNullOrEmpty(monthChoice)){
				monthValid =false;
			}
			//This if statement structure converts the month string  into  its integer equivalent
			if  (monthChoice == "January" )
			{
				monthValid = true;
				monthInput = 1;
			}else if(monthChoice == "February")
			{
				monthInput = 2;
				monthValid = true;
			}
			else if(monthChoice== "March")
			{
				monthInput = 3;
				monthValid = true;
			}else if(monthChoice == "April")
			{
				monthInput = 4;
				monthValid=true;
			}else if(monthChoice == "May")
			{
				monthInput = 5;
				monthValid=true;
			}else if(monthChoice == "June")
			{
				monthInput = 6;
				monthValid=true;
			}else if(monthChoice == "July")
			{
				monthInput = 7;
				monthValid=true;
			}else if(monthChoice == "August")
			{
				monthInput = 8;
				monthValid=true;
			}else if(monthChoice == "September")
			{
				monthInput = 9;
				monthValid=true;
			}else if(monthChoice == "October")
			{
				monthInput = 10;
				monthValid=true;
			}else if(monthChoice == "November")
			{
				monthInput = 11;
				monthValid=true;
			}else if (monthChoice == "December")
			{
				monthInput = 12;
				monthValid=true;
			}else{
				//if the month choice doesn't match a month then display error message
				Console.WriteLine("Invalid input. Plesase type in a month !!");
				monthValid = false;
			}
		}while(monthValid == false);
		//Changes the selected Column to so it can sort  and search the months 
		selectedColumn =1;
		// sets it to ascending order sorting 
		orderChoice = 'a';
		//Calls Quick Sort function for both stations because the months need to be sorted before using a binary search 
		Sort.QuickSort(tempWS1DataArray,selectedColumn,orderChoice);
		Sort.QuickSort(tempWS2DataArray,selectedColumn,orderChoice);
		//Reset iteration and occurence counters for each searching algorithm
		Searching.binarySearchIterations = 0;
		Searching.binaryHybridOccur = 0;
		Searching.linearSearchIteration = 0 ;
		Searching.linearSearchOccur = 0;
		//Reset  binary search hybrid occurences  for both stations 
		WS1NumOfOccurences = 0;
		WS2NumOfOccurences = 0;
		Console.WriteLine("WS1 Search Results");
		//Call recursive binary search function to search weather station 1 data  and then store its found index
		foundIndex = Searching.BinarySearch_R(monthInput,tempWS1DataArray,0,1022,selectedColumn);
		//Display number of binary search iternations for weather station 1 data 
		Console.WriteLine("WS1:Total number of iternations for binary search:"+Searching.binarySearchIterations);
		Console.ReadLine();
		//If the binary search doesn't find the data don't do binary search hybrid code and go straight to the linear search
		if (foundIndex != -1)
		{
			//If binary search is successful then display the index the data was found
			Console.WriteLine("The binary search found the data at index: {0}",foundIndex);
			int []monthWS1OccurIndexs = new int [Searching.binaryHybridOccur];//Create an array to store the multiple indexs for multiple occurences of that data for weather station 1 
			Console.WriteLine("As binary search is only effective for searching for  one value, we had to use a linear search or Binary Search Hybrid to find all corresponding values ");
			//Call the  binary search hybrid function to check for multiple occurences of that data for weather station 1 
			monthWS1OccurIndexs = Searching.BinarySearchHybrid(monthInput,tempWS1DataArray,selectedColumn,foundIndex);
			DisplayColumnNames();
			WS1NumOfOccurences = Searching.binaryHybridOccur - Searching.binarySearchIterations; // Get the number of occurences and store it .For weather station 1
			//Displays the results of the binary search hybrid  for weather station 1 
			DisplaySearchResults(tempWS1DataArray,monthWS1OccurIndexs,WS1NumOfOccurences);
			// Display binary search hybrid  iternations  for weather station 1 
			Console.WriteLine("WS1:Total number of iternations for Binary Search Hybrid:"+ Searching.binaryHybridOccur);
		}
		Console.ReadLine();
		int []monthWS1LinearOccurIndexs = new int [Searching.linearSearchOccur];// Gets the number of occurences of that data in a linear search for weather station 1
		//Call the Linear Search function and  get the indexs of the occurences of the data that the user is searching for 
		monthWS1LinearOccurIndexs = Searching.LinearSearch(monthInput,tempWS1DataArray,foundIndex,selectedColumn);
		//Checks if there is  any results to display
		if (Searching.linearSearchOccur== 0)
		{
			// if not  then display nothing 	
		}else
		{
			// if there are results display the table column names 
			DisplayColumnNames();
		}
		//Displays the results of the linear search  for weather station 1 
		DisplaySearchResults(tempWS1DataArray,monthWS1LinearOccurIndexs,Searching.linearSearchOccur);
		//Display linear search iterations  for weather station 1 
		Console.WriteLine("WS1:Total number of iternations for Linear (Sequential) Search :"+Searching.linearSearchIteration);
		Console.WriteLine("	");
		Console.ReadLine();
		//Reset iteration and occurence counters for each searching algorithm
		Searching.binarySearchIterations = 0;
		Searching.binaryHybridOccur = 0;
		Searching.linearSearchIteration = 0 ;
		Searching.linearSearchOccur = 0;
		Console.WriteLine("WS2 Search Results");
		//Call recursive binary search function to search weather station 2 data  and then store its found index
		foundIndex = Searching.BinarySearch_R(monthInput,tempWS2DataArray,0,1022,selectedColumn);
		//Display number of binary search iternations for weather station 2 data 
		Console.WriteLine("WS2:Total number of iternations for Binary  Search:"+Searching.binarySearchIterations);
		Console.ReadLine();
		//If the binary search doesn't find the data don't do binary search hybrid code and go straight to the linear search
		if (foundIndex != -1)
		{
			int []monthWS2OccurIndexs= new int [Searching.binaryHybridOccur];//Create an array to store the multiple indexs for multiple occurences of that data for weather station 1 
			Console.WriteLine("As binary search is only effective for searching for  one value, we had to use a linear search or Binary Search Hybrid to find all corresponding values ");
			//Call the  binary search hybrid function to check for multiple occurences of that data for weather station 1 
			monthWS2OccurIndexs = Searching.BinarySearchHybrid(monthInput,tempWS2DataArray,selectedColumn,foundIndex);
			DisplayColumnNames();
			WS2NumOfOccurences = Searching.binaryHybridOccur - Searching.binarySearchIterations; // Get the number of occurences and store it. For weather station 2 
			//Displays the results of the binary search hybrid  for weather station 2
			DisplaySearchResults(tempWS2DataArray,monthWS2OccurIndexs,WS2NumOfOccurences);
			// Display binary search hybrid  iternations  for weather station 2
			Console.WriteLine("WS2:Total number of iternations for Binary  Search Hybrid:"+ Searching.binaryHybridOccur);
			Console.ReadLine();
		}
		int []monthWS2LinearOccurIndexs = new int [Searching.linearSearchOccur];// Gets the number of occurences of that data in a linear search for weather station 2
		//Call the Linear Search function and  get the indexs of the occurences of the data that the user is searching for 
		monthWS2LinearOccurIndexs = Searching.LinearSearch(monthInput,tempWS2DataArray,foundIndex,selectedColumn);
		//Checks if there is  any results to display
		if (Searching.linearSearchOccur == 0)
		{
			// if not  then display nothing 	
		}else
		{
			// if there are results display the table column names 
			DisplayColumnNames();
		}
		//Displays the results of the linear search  for weather station 2 
		DisplaySearchResults(tempWS2DataArray,monthWS2LinearOccurIndexs,Searching.linearSearchOccur);
		//Display linear search iterations  for weather station 2
		Console.WriteLine("WS2:Total number of iternations for Linear (Sequential) Search :"+Searching.linearSearchIteration);
		Console.WriteLine("	");
		
	}
	public static void DisplayColumnNames()
	{
		//Array that holds column titles for the table
		string []columnTitles = {"Years","Month","MDTMaxmium(in C)","MDTMinmium(in C)","Days of Air Frost","Total Rainfall(in mm)","Total Sunshine duration(in hours)"};
		//This for loop displays each of the Column Titles
		for( int row = 0; row < 7; row++)
		{
			Console.Write("{0,-22}",columnTitles[row]);
		}
		Console.WriteLine("	");
	}
	public static void DisplayMaxMinMedian(double[,] weatherData , int displayColumn,char order)
	{
		/*This Switch case displays the correct column title for the correct selected column 
			to display with the maximium , median and minimium values.
		*/
		switch (displayColumn)
		{
			case 0:
				//Because years doesn't have maximium,median and minimium values it doesn't display the years column title
			break;
			case 1:
				//Because months doesn't have maximium,median and minimium values it doesn't display the months column title
			break;
			case 2:
				Console.WriteLine("Mean Daily Temperature Maximium");
			break;
			case 3:
				Console.WriteLine("Mean Daily Temperature Minimium");
			break;
			case 4:
				Console.WriteLine("Days of Air Frost");
			break;
			case 5:
				Console.WriteLine("Total Rainfall");
			break;
			case 6:
				Console.WriteLine("Total Sunshine duration");
			break;
		}
		if (displayColumn == 0 | displayColumn == 1)
		{
			/*Because years and months doesn't have maximium,median and minimium 
				values it doesn't display the maximium , median and minimium values.			
			*/
		}else
		{
			//Display maximium , median and minimium for all the other columns
			//if it is ascending order do this code
			if(order == 'a')
			{
				int maximium = 1021;//If the array is sorted then the maximium would be at 1021 index
				int median = 0;//Stores the median index 
				int minimium = 0;//If the array is sorted then the minimium would be at 0 index
				Console.WriteLine("Maximium value: "+ weatherData[1021,displayColumn]);
				DisplayColumnNames();
				DisplayMaxMinMedRow(weatherData,maximium);
				Console.WriteLine("	");
				//Creates temparray to work out the length and get the middle index
				double []temparray = new double [1022];
				for(int index = 0; index <1022; index++)
				{
					temparray[index]= weatherData[index,displayColumn];
				}
				int middle = temparray.Length/2;
				double medianValue = (middle-1 + middle) / 2;//calculates median index 
				median =Convert.ToInt32(Math.Round(medianValue));// rounds  the median index  up 
				Console.WriteLine("Median value:  	"+ weatherData[median,displayColumn]);
				DisplayColumnNames();
				DisplayMaxMinMedRow(weatherData,median);
				Console.WriteLine("	");
				Console.WriteLine("Minimium value:  "+ weatherData[0,displayColumn]);	
				DisplayColumnNames();
				DisplayMaxMinMedRow(weatherData,minimium);
			}
			//Else if it is descending order do this code
			else if(order == 'd')
			{
				int maximium = 0;//If the array is sorted then the maximium would be at 0 index
				int median = 0;//Stores the median index 
				int minimium =1021;//If the array is sorted then the minimium would be at 1021 index
				Console.WriteLine("Maximium value: "+ weatherData[0,displayColumn]);
				DisplayColumnNames();
				DisplayMaxMinMedRow(weatherData,maximium);
				Console.WriteLine("	");
				//Creates temparray to work out the length and get the middle index
				double []temparray = new double [1022];
				for(int index = 0; index <1022; index++)
				{
					temparray[index]= weatherData[index,displayColumn];
				}
				int middle = temparray.Length/2;
				double medianValue =(middle-1 + middle) / 2;//calculates median index 
				median =Convert.ToInt32(Math.Round(medianValue));// rounds  the median index  up 
				Console.WriteLine("Median value:  	"+ weatherData[median,displayColumn]);
				DisplayColumnNames();
				DisplayMaxMinMedRow(weatherData,median);
				Console.WriteLine("	");
				Console.WriteLine("Minimium value:  "+ weatherData[1021,displayColumn]);	
				DisplayColumnNames();
				DisplayMaxMinMedRow(weatherData,minimium);
			}
		}
	}
	public static void DisplayMaxMinMedRow (double[,]weatherStatData,int statIndex)
	{
		string displayMonth = "";//Used to store a month as a string 
		//Loops through each column to display its data
		for (int column = 0; column < 7; column++)
		{	
			// 1 is the month column so we output the string equivalent to what is stored in the array
			if (column == 1 )
			{
				//This series of if and else if statements convert the months from double to its  string equivalent 
				if (weatherStatData[statIndex,column] == 1)
				{
					displayMonth = "January";
					Console.Write("{0,-22}", displayMonth);
				}else if(weatherStatData[statIndex,column] == 2)
				{
					displayMonth = "February";
					Console.Write("{0,-22}", displayMonth);
				}else if(weatherStatData[statIndex,column] == 3)
				{
					displayMonth = "March";
					Console.Write("{0,-22}", displayMonth);
				}else if(weatherStatData[statIndex,column]== 4)
				{
					displayMonth = "April";
					Console.Write("{0,-22}", displayMonth);
				}else if(weatherStatData[statIndex,column]== 5)
				{
					displayMonth = "May";
					Console.Write("{0,-22}", displayMonth);
				}else if(weatherStatData[statIndex,column] == 6)
				{
					displayMonth = "June";
					Console.Write("{0,-22}", displayMonth);
				}else if(weatherStatData[statIndex,column] == 7)
				{
					displayMonth = "July";
					Console.Write("{0,-22}", displayMonth);
				}else if(weatherStatData[statIndex,column] == 8)
				{
					displayMonth = "August";
					Console.Write("{0,-22}", displayMonth);
				}else if(weatherStatData[statIndex,column] == 9)
				{
					displayMonth = "September";
					Console.Write("{0,-22}", displayMonth);
				}else if(weatherStatData[statIndex,column] == 10)
				{
					displayMonth = "October";
					Console.Write("{0,-22}", displayMonth);
				}else if(weatherStatData[statIndex,column] == 11)
				{
					displayMonth = "November";
					Console.Write("{0,-22}", displayMonth);
				}else if (weatherStatData[statIndex,column] == 12)
				{
					displayMonth = "December";
					Console.Write("{0,-22}", displayMonth);
				}
			}
			//If its not column 1 then display the data stored in that column 
			else
			{
				Console.Write("{0,-22}",weatherStatData[statIndex,column]);
			}
		}
	}
	public static double[,] ReadWS1Files()
	{
		//Declare 2d array to store everything from Weather Station 1 files 
		double[,] fileDataArray = new double [1022,7];
		string[] yearText = new string [1022];//Stores Years from Year.txt file 
		string[] monthText = new string[1022];//Stores Months from Month.txt
		string[] tMaxText = new string[1022];// Stores the Mean Daily Temperature Maximium  from WS1_TMax.txt
		string[] tMinText = new string [1022];// Stores the Mean Daily Temperature Minimium  from WS1_TMin.txt
		string[] aFText = new string [1022];//Stores the days of air frost from WS1_AF.txt
		string[] rainText = new string[1022];//Stores the total rainfall (in mm) from WS1_Rain.txt
		string[] sunText = new string[1022];//Store the total sunshine duration (in hours) from WS1_Sun.txt
		// Reads the file Year.txt and stores it in fileText
		yearText = File.ReadAllLines(@"Year.txt");
		//Call the TransferFileArray function to put the YearText into the 2d Array 
		fileDataArray = TransferFileArray(fileDataArray,yearText,0);
		//Reads the file Month.txt and stores it in MonthText
		monthText = File.ReadAllLines(@"Month.txt");
		//This for loop moves through the MonthText array and converts the months from string to double 
		for (int row = 0 ; row < 1022; row++)
		{
			//Checks what month that this index contains and then converts it 
			switch (monthText[row])
			{
				case "January":
					 monthText[row] = "1.0";
				break;
				case "February":
					monthText[row] = "2.0";
				break;
				case "March":
					monthText[row] = "3.0";
				break;
				case "April":
					monthText[row] = "4.0";
				break;
				case "May":
					monthText[row] = "5.0";
				break;
				case "June":
					monthText[row] = "6.0";
				break;
				case "July":
					monthText[row] = "7.0";
				break;
				case "August":
					monthText[row] = "8.0";
				break;
				case "September":
					monthText[row] = "9.0";
				break;
				case "October":
					monthText[row] = "10.0";
				break;
				case "November":
					monthText[row] = "11.0";
				break;
				case "December":
					monthText[row] = "12.0";
				break;
				default:
				break;
			}
		}
		 
		//Call the TransferFileArray function to put the MonthText into the 2d Array 
		//The number in that is passed as a parameter is the column in the 2d array  
		fileDataArray = TransferFileArray(fileDataArray,monthText,1);
		//Reads the file WS1_TMax.txt and put it in tMaxText
		tMaxText = File.ReadAllLines(@"WS1_TMax.txt");
		//Call the TransferFileArray function to put the tMaxText into the 2d Array 
		fileDataArray = TransferFileArray(fileDataArray,tMaxText,2);
		//Reads the file WS1_TMin.txt and put it in tMinText
		tMinText = File.ReadAllLines(@"WS1_TMin.txt");
		//Call the TransferFileArray function to put the tMinText into the 2d Array 
		fileDataArray = TransferFileArray(fileDataArray,tMinText,3);
		//Reads the file WS1_AF.txt and put it in aFText
		aFText = File.ReadAllLines(@"WS1_AF.txt");
		//Call the TransferFileArray function to put the aFText into the 2d Array 
		fileDataArray = TransferFileArray(fileDataArray,aFText,4);
		//Reads the file WS1_Rain.txt and put it in RainText
		rainText = File.ReadAllLines(@"WS1_Rain.txt");
		//Call the TransferFileArray function to put the RainText into the 2d Array 
		fileDataArray = TransferFileArray(fileDataArray,rainText,5);
		//Reads the file WS1_Sun.txt and put it in SunText
		sunText = File.ReadAllLines(@"WS1_Sun.txt");
		//Call the TransferFileArray function to put the SunText into the 2d Array 
		fileDataArray = TransferFileArray(fileDataArray,sunText,6);
		return fileDataArray;
	}
	public static double[,] ReadWS2Files()
	{
		//Declare 2d array to store everything from Weather Station 1 files 
		double[,] fileDataArray2 = new double [1022,7];
		string[] yearText2 = new string [1022];//Stores Years from Year.txt file 
		string[] monthText2 = new string[1022];//Stores Months from Month.txt
		string[] tMaxText2 = new string[1022];// Stores the Mean Daily Temperature Maximium  from WS2_TMax.txt
		string[] tMinText2 = new string [1022];// Stores the Mean Daily Temperature Minimium  from WS2_TMin.txt
		string[] aFText2 = new string [1022];//Stores the days of air frost from WS2_AF.txt
		string[] rainText2 = new string[1022];//Stores the total rainfall (in mm) from WS2_Rain.txt
		string[] sunText2 = new string[1022];//Store the total sunshine duration (in hours) from WS2_Sun.txt
		// Reads the file Year.txt and stores it in fileText2
		yearText2 = File.ReadAllLines(@"Year.txt");
		//Call the TransferFileArray function to put the YearText2 into the 2d Array 
		fileDataArray2 = TransferFileArray(fileDataArray2,yearText2,0);
		//Reads the file Month.txt and stores it in MonthText2
		monthText2 = File.ReadAllLines(@"Month.txt");
		//This for loop moves through the MonthText2 array and converts the months from string to double 
		for (int row = 0 ; row < 1022; row++)
		{
			//Checks what month that this index contains and then converts it 
			switch (monthText2[row])
			{
				case "January":
					 monthText2[row] = "1.0";
				break;
				case "February":
					monthText2[row] = "2.0";
				break;
				case "March":
					monthText2[row] = "3.0";
				break;
				case "April":
					monthText2[row] = "4.0";
				break;
				case "May":
					monthText2[row] = "5.0";
				break;
				case "June":
					monthText2[row] = "6.0";
				break;
				case "July":
					monthText2[row] = "7.0";
				break;
				case "August":
					monthText2[row] = "8.0";
				break;
				case "September":
					monthText2[row] = "9.0";
				break;
				case "October":
					monthText2[row] = "10.0";
				break;
				case "November":
					monthText2[row] = "11.0";
				break;
				case "December":
					monthText2[row] = "12.0";
				break;
				default:
				break;
			}
		}
		 //Call the TransferFileArray function to put the MonthText2 into the 2d Array 
		//The number in that is passed as a parameter is the column in the 2d array  
		fileDataArray2 = TransferFileArray(fileDataArray2,monthText2,1);
		//Reads the file WS2_TMax.txt and put it in tMaxText2
		tMaxText2 = File.ReadAllLines(@"WS2_TMax.txt");
		//Call the TransferFileArray function to put the tMaxText into the 2d Array 
		fileDataArray2 = TransferFileArray(fileDataArray2,tMaxText2,2);
		//Reads the file WS2_TMin.txt and put it in tMinText2
		tMinText2 = File.ReadAllLines(@"WS2_TMin.txt");
		//Call the TransferFileArray function to put the tMinText into the 2d Array 
		fileDataArray2 = TransferFileArray(fileDataArray2,tMinText2,3);
		//Reads the file WS2_AF.txt and put it in aFText2
		aFText2 = File.ReadAllLines(@"WS2_AF.txt");
		//Call the TransferFileArray function to put the aFText into the 2d Array 
		fileDataArray2 = TransferFileArray(fileDataArray2,aFText2,4);
		//Reads the file WS2_Rain.txt and put it in RainText2
		rainText2 = File.ReadAllLines(@"WS2_Rain.txt");
		//Call the TransferFileArray function to put the RainText into the 2d Array 
		fileDataArray2 = TransferFileArray(fileDataArray2,rainText2,5);
		//Reads the file WS2_Sun.txt and put it in SunText2
		sunText2 = File.ReadAllLines(@"WS2_Sun.txt");
		//Call the TransferFileArray function to put the SunText2 into the 2d Array 
		fileDataArray2 = TransferFileArray(fileDataArray2,sunText2,6);
		return fileDataArray2;
	}
	public static double [,]TransferFileArray(double[,] file2DDataArray,string [] fileText, int column)
	{	
		double [] fileArray =new double[1022];// Temporary array to store the converted array
		//Loops through and converts the string array into a double array 
		for (int index = 0; index < 1022; index++)
		{
			//Converting from string  to double 
			fileArray[index] = Convert.ToDouble(fileText[index]);
		}
		//Loops through and add the temporary array to the 2d array 
		for (int row = 0 ; row < 1022; row++)
		{	
			//Uses temp to temporary hold a value when transfering the array to the 2d array
			double temp = fileArray[row];
			file2DDataArray[row,column] = temp;
		}
		return file2DDataArray;
	}
	public static double [,]ResetFileArray(double[,]originalArray, double[,]resetArray)
	{	
		//Loops through  both rows and columns to reset the resetArray with the originalArray 
		for (int row =0 ; row < 1022; row++)
		{
			for(int column = 0; column < 7; column++)
			{
				resetArray[row,column] = originalArray[row,column];
			}
		}
		return resetArray;
	}
	public static void DisplayWeatherData(double [,]weatherDataArray)
	{
		string displayMonth = "";//Used to store a month as a string 
		//Loops through each row to display its data
		for (int row  = 0 ; row < 1022; row++)
		{	
			//Loops through each column to display its data
			for (int column = 0; column < 7; column ++)
			{
				// 1 is the month column so we output the string equivalent to what is stored in the array
				if (column == 1 )
				{
					//This series of if and else if statements convert the months from double  to its  string equivalent 
					if (weatherDataArray[row,column] == 1)
					{
						displayMonth = "January";
						Console.Write("{0,-22}", displayMonth);
					}else if(weatherDataArray[row,column] == 2)
					{
						displayMonth = "February";
						Console.Write("{0,-22}", displayMonth);
					}else if(weatherDataArray[row,column] == 3)
					{
						displayMonth = "March";
						Console.Write("{0,-22}", displayMonth);
					}else if(weatherDataArray[row,column] == 4)
					{
						displayMonth = "April";
						Console.Write("{0,-22}", displayMonth);
					}else if(weatherDataArray[row,column] == 5)
					{
						displayMonth = "May";
						Console.Write("{0,-22}", displayMonth);
					}else if(weatherDataArray[row,column] == 6)
					{
						displayMonth = "June";
						Console.Write("{0,-22}", displayMonth);
					}else if(weatherDataArray[row,column] == 7)
					{
						displayMonth = "July";
						Console.Write("{0,-22}", displayMonth);
					}else if(weatherDataArray[row,column] == 8)
					{
						displayMonth = "August";
						Console.Write("{0,-22}", displayMonth);
					}else if(weatherDataArray[row,column] == 9)
					{
						displayMonth = "September";
						Console.Write("{0,-22}", displayMonth);
					}else if(weatherDataArray[row,column] == 10)
					{
						displayMonth = "October";
						Console.Write("{0,-22}", displayMonth);
					}else if(weatherDataArray[row,column] == 11)
					{
						displayMonth = "November";
						Console.Write("{0,-22}", displayMonth);
					}else if (weatherDataArray[row,column] == 12)
					{
						displayMonth = "December";
						Console.Write("{0,-22}", displayMonth);
					}
					//If its not column 1 then display the data stored in that column  
				}else
				{
					Console.Write("{0,-22}",weatherDataArray[row,column]);
				}
			}
			Console.WriteLine("	");
		}
	}
	public static void DisplaySearchResults(double[,] resultArray ,int[] resultIndex ,int occurenceCount)
	{
		string displayMonth = "";//Used to store a month as a string 
		//Loops through each occurence stored in the resultIndex array to display its data for that row in the resultArray
		for (int occurence = 0; occurence < occurenceCount;occurence++)
		{
			//Loops through each column to display its data
			for (int column = 0; column < 7; column++)
			{
				// 1 is the month column so we output the string equivalent to what is stored in the  result array
				if (column == 1 )
				{
					//This series of if and else if statements convert the months from double  to its  string equivalent 
					if  (resultArray[resultIndex[occurence],column] == 1)
					{
						displayMonth = "January";
						Console.Write("{0,-22}", displayMonth);
					}else if(resultArray[resultIndex[occurence],column] == 2)
					{
						displayMonth = "February";
						Console.Write("{0,-22}", displayMonth);
					}else if(resultArray[resultIndex[occurence],column] == 3)
					{
						displayMonth = "March";
						Console.Write("{0,-22}", displayMonth);
					}else if(resultArray[resultIndex[occurence],column] == 4)
					{
						displayMonth = "April";
						Console.Write("{0,-22}", displayMonth);
					}else if(resultArray[resultIndex[occurence],column] == 5)
					{
						displayMonth = "May";
						Console.Write("{0,-22}", displayMonth);
					}else if(resultArray[resultIndex[occurence],column] == 6)
					{
						displayMonth = "June";
						Console.Write("{0,-22}", displayMonth);
					}else if(resultArray[resultIndex[occurence],column] == 7)
					{
						displayMonth = "July";
						Console.Write("{0,-22}", displayMonth);
					}else if(resultArray[resultIndex[occurence],column] == 8)
					{
						displayMonth = "August";
						Console.Write("{0,-22}", displayMonth);
					}else if(resultArray[resultIndex[occurence],column] == 9)
					{
						displayMonth = "September";
						Console.Write("{0,-22}", displayMonth);
					}else if(resultArray[resultIndex[occurence],column] == 10)
					{
						displayMonth = "October";
						Console.Write("{0,-22}", displayMonth);
					}else if(resultArray[resultIndex[occurence],column] == 11)
					{
						displayMonth = "November";
						Console.Write("{0,-22}", displayMonth);
					}else if (resultArray[resultIndex[occurence],column] == 12)
					{
						displayMonth = "December";
						Console.Write("{0,-22}", displayMonth);
					}
				}
				//If its not column 1 then display the data stored in that column 
				else
				{
					Console.Write("{0,-22}",resultArray[resultIndex[occurence],column]);
				}
			}
			Console.WriteLine("	");
		}
	}
}
public class Sort{
	public  static int quickSortIteration;
	public  static int bubbleSortIteration;
	public static int insertionSortIteration;
	public static int mergeSortIteration;
	public static int heapSortIteration;
	public static double[,] QuickSort(double[,]quickSortData,int selectedColumn,char order)
	{
		//Calls the recursive quick sort function and uses 0 and 122 because that is the lowest and highest index of the array
		Quick_Sort(quickSortData, 0, 1021,selectedColumn,order);
		return quickSortData;
	}
	public static void Quick_Sort(double[,] quickSortData, int left, int right,int selectedColumn,char order)
	{
		int low, high;
		double quickSortpivot, temp;
		//Assigns the far left index as the lowest index and assigns the far right index as the highest index 
		low = left;
		high = right;
		//Calculate the pivot index value 
		quickSortpivot = quickSortData[((left + right) / 2),selectedColumn];
		//Loop until the low variable is greater or not equal to high variable 
		do
		{	
			//if it is sorting ascending order do this  
			if(order =='a')
			{
				//If low is less than or equal to high variable then perform the swapping of data 
				//Compares if the quickSortdata array is less than the pivot value until it is greater than the pivot value  and if the low index has reached the far right of the array.
				while ((quickSortData[low,selectedColumn] < quickSortpivot) && (low < right))
				{
					low++; 
					quickSortIteration++;//Count the iterations of quick sort
				}
				//Compares if the quickSortdata array is greater than the pivot value until it is less than the pivot value  and if the high index has reached the far left of the array.
				while ((quickSortpivot < quickSortData[high,selectedColumn]) && (high > left)) 
				{
					high--; 
					quickSortIteration++;//Count the iterations of quick sort
				}
			}
			//if it is sorting descending order do this 
			else if(order =='d')
			{
				//If low is  than or equal to high variable then perform the swapping of data 
				//Compares if the quickSortdata array is greater than the pivot value until it is greater than the pivot value  and if the low index has reached the far right of the array.
				while ((quickSortData[low,selectedColumn] > quickSortpivot) && (low < right))
				{
					low++; 
					quickSortIteration++;//Count the iterations of quick sort
				}
				//Compares if the quickSortdata array is less than the pivot value until it is less than the pivot value  and if the high index has reached the far left of the array.
				while ((quickSortpivot > quickSortData[high,selectedColumn]) && (high > left)) 
				{
					high--; 
					quickSortIteration++;//Count the iterations of quick sort
				}
			}
			if (low<= high)
			{
				//this for loop rearranges each column based on the selected column that is being sorted 
				for(int column = 0; column < 7; column++)
				{
					//Swaps the values 
					temp =quickSortData[low,column];
					quickSortData[low,column]= quickSortData[high,column];
					quickSortData[high,column] = temp;
				}
				low++;
				high--;
			}
			
		} while (low<= high);
		//Checks if the left index has reached the high index then calls the recursive function
		if (left < high)
		{
			Quick_Sort(quickSortData, left, high,selectedColumn,order);
		}
		//Checks if the right index has reached the low index then calls the recursive function
		if (low < right)
		{ 
			Quick_Sort(quickSortData, low,right, selectedColumn,order);
		}
	}	
	public static double [,] BubbleSort(double[,] bubbleSortData,int selectedColumn,char order)
	{
		//The two for loops check and then swaps the two adjacent rows of the data
		for(int row1 = 0; row1 < 1022; row1++)
		{
			for(int row2 = 0; row2 < 1021 - row1;row2++)
			{
				bubbleSortIteration++;//Count the iterations of bubble  sort
				//if it is sorting in ascending order do this code 
				if(order == 'a'){
					//Compares the two adjacent row in the selected column 
					if(bubbleSortData[row2+1,selectedColumn]< bubbleSortData[row2,selectedColumn])
					{
						 
						 // Swaps all the columns between two rows based on the selected column.
						for(int column = 0; column< 7; column++)
						{
							double temp = bubbleSortData[row2,column];
							bubbleSortData[row2,column] = bubbleSortData[row2+1,column];
							bubbleSortData[row2+1,column] = temp;
						}
					}
				}
				//if it is sorting in descending order do this code 
				else if(order == 'd')
				{
					//Compares the two adjacent row in the selected column 
					if(bubbleSortData[row2+1,selectedColumn]> bubbleSortData[row2,selectedColumn])
					{
						 // Swaps all the columns between two rows based on the selected column.
						for(int column = 0; column< 7; column++)
						{
							double temp = bubbleSortData[row2,column];
							bubbleSortData[row2,column] = bubbleSortData[row2+1,column];
							bubbleSortData[row2+1,column] = temp;
						}
					}
				}
			}
		}
		return bubbleSortData;
	}
	public static double[,] InsertionSort(double[,] insertionSortData,int selectedColumn,char order)
	{
		int itemsToSort =1022;
		int numSorted = 1; // number of values in the correct place
		int insertionIndex; // general index
		//Loops until all the items are sorted 
		while (numSorted < itemsToSort)
		{
			double temp = insertionSortData[numSorted,selectedColumn];
			//loops through and swaps values based on if the temp is than that position that the index points to 
			for (insertionIndex = numSorted; insertionIndex > 0; insertionIndex--)
			{
				insertionSortIteration++;//Count the iterations of insertion sort
				//if ascending order do this code
				if(order=='a')
				{
					if (temp < insertionSortData[insertionIndex-1,selectedColumn])
					{
						insertionSortData[insertionIndex,selectedColumn] = insertionSortData[insertionIndex-1,selectedColumn];
					}else 
					{
						break;
					}
				}
				//if descending order do this code 
				else if(order=='d'){
					if (temp > insertionSortData[insertionIndex-1,selectedColumn])
					{
						insertionSortData[insertionIndex,selectedColumn] = insertionSortData[insertionIndex-1,selectedColumn];
					}else 
					{
						break;
					}
				}
			}
			insertionSortData[insertionIndex,selectedColumn] = temp;
			numSorted++;
		}	
		return insertionSortData;
	}
	public static void Merge(double[,] mergeSortData,double[,] tempMergeSortData, int low, int middle, int high,int selectedColumn,char order)
	{
		int resultIndex = low; // Holds the result index
		int tempIndex = low; // Holds the temp index
		int destinationIndex = middle; // Holds the destination index
		// while two lists are not empty merge smaller value
		while (tempIndex < middle && destinationIndex <= high)
		{
			//if ascending order do this code 
			if(order=='a')
			{
				mergeSortIteration++;//Count the iterations of merge sort
				if (mergeSortData[destinationIndex,selectedColumn] < tempMergeSortData[tempIndex,selectedColumn]) 
				{
					mergeSortData[resultIndex++,selectedColumn] = mergeSortData[destinationIndex++,selectedColumn];
					// smaller value  is in high data
				}else 
				{
					mergeSortData[resultIndex++,selectedColumn] = tempMergeSortData[tempIndex++,selectedColumn];// the smaller  value is in tempMergeSortData array
				}
			}
			//if descending order do this code 
			else if(order=='d')
			{
				mergeSortIteration++;//Count the iterations of merge sort
				if (mergeSortData[destinationIndex,selectedColumn] > tempMergeSortData[tempIndex,selectedColumn]) 
				{
					mergeSortData[resultIndex++,selectedColumn] = mergeSortData[destinationIndex++,selectedColumn];
					// larger value  is in high data
				}else 
				{
					mergeSortData[resultIndex++,selectedColumn] = tempMergeSortData[tempIndex++,selectedColumn];// the larger  value is in tempMergeSortData array
				}
			}
		}
		//Some values can be  left in tempMergeSortData array
		while (tempIndex < middle)
		{
			mergeSortIteration++;//Count the iterations of merge sort
			mergeSortData[resultIndex++,selectedColumn] = tempMergeSortData[tempIndex++,selectedColumn];
		}
		//some values can be  left (in correct place) in  the mergeSortData array
	}
	public static void MergeSortRecursive(double[,] mergeSortData,double[,] tempMergeSortData, int low, int high,int selectedColumn,char order)
	{
		int runSize = high-low+1;//Stores the runSize
		int middle = low + runSize/2;//Stores the middle of the array 
		int moveCounter;// A count used for moving half the data to temporary storage
		if (runSize < 2) return;
		// move lower half of data into tempMergeSortData storage
		for (moveCounter = low; moveCounter < middle; moveCounter++)
		{
			tempMergeSortData[moveCounter,selectedColumn] = mergeSortData[moveCounter,selectedColumn];
		}
		// sort lower half of the array
		MergeSortRecursive(tempMergeSortData,mergeSortData, low, middle-1,selectedColumn,order);
		// sort upper half pf the  array
		MergeSortRecursive(mergeSortData,tempMergeSortData,middle,high,selectedColumn,order);
		// merge the halves together
		Merge(mergeSortData,tempMergeSortData, low, middle, high,selectedColumn,order);
	}
	public static void MergeSort(double [,]mergeSortData,int selectedColumn,char order)
	{
		double[,] tempMergeSortData = new double [1022,7];
		MergeSortRecursive(mergeSortData, tempMergeSortData, 0, 1021,selectedColumn,order);
	}
	public static void HeapSort(double [,] heapSortData,int selectedColumn,char order)
	{
		int heapSize = 1022;//Stores the heap size
		int heapCounter;//Stores the heap counter
		//loops through the heap and then calls the MaxHeapify function and that sorts it 
		for (heapCounter = (heapSize - 1) / 2; heapCounter >= 0; heapCounter--)
		{
			//if ascending do this code 
			if(order =='a')
			{
				MaxHeapify(heapSortData, heapSize,heapCounter,selectedColumn);
			}
			//else if it is descending do this code
			else if (order == 'd'){
				MinHeapify(heapSortData,heapSize,heapCounter,selectedColumn);
			}
		}
		//loops through  and performs swaps and then calls the MaxHeapify function
		for (heapCounter = 1021; heapCounter > 0; heapCounter--)
		{				
			double temp = heapSortData[heapCounter,selectedColumn];
			heapSortData[heapCounter,selectedColumn] = heapSortData[0,selectedColumn];
			heapSortData[0,selectedColumn] = temp;
			heapSize--;
			//if ascending do this code 
			if(order == 'a')
			{
				MaxHeapify(heapSortData, heapSize, 0,selectedColumn);
			}
			//else if it is descending do this code
			else if (order == 'd')
			{
				MinHeapify(heapSortData,heapSize,0,selectedColumn);
			}
		}
	}
	private static void MaxHeapify(double[,] heapSortData, int heapSize, int heapIndex,int selectedColumn)
	{
		int left = (heapIndex + 1) * 2 - 1;//Used for the left node
		int right = (heapIndex + 1) * 2;//Used for the right node 
		int largest = 0;//Used to store the largest value 
		heapSortIteration++;//Count the iterations of heap sort
		//Checks if the left index has reached the heap size and checks that the left has the largest value if it does then store it in largest. if it doesn't then store the heapIndex
		if (left < heapSize && heapSortData[left,selectedColumn] > heapSortData[heapIndex,selectedColumn])
		{
			largest = left;
		}else
		{
			largest = heapIndex;
		}
		//Checks if the right index has reached the heap size and checks that the right has the largest value if it does then store it in largest. if it doesn't then store the heapIndex
		if (right < heapSize && heapSortData[right,selectedColumn] > heapSortData[largest,selectedColumn])
		{
			largest = right;
		}
		//if the largest is not equal to the heapIndex then perform swaps and call MaxHeapify
		if (largest != heapIndex)
		{
			//sorting  rows based on the sorted column
			for(int column= 0; column <7; column++)
			{	
				double temp = heapSortData[heapIndex,column];
				heapSortData[heapIndex,column] = heapSortData[largest,column];
				heapSortData[largest,column] = temp;
			}
			MaxHeapify(heapSortData, heapSize, largest,selectedColumn);
		}
		
	}private static void MinHeapify(double[,] heapSortData, int heapSize, int heapIndex,int selectedColumn)
	{
		int left = (heapIndex + 1) * 2 - 1;//Used for the left node
		int right = (heapIndex + 1) * 2;//Used for the right node 
		int smallest = 0;//Used to store the smallest value 
		heapSortIteration++;//Count the iterations of heap sort
		//Checks if the left index has reached the heap size and checks that the left has the smallest value if it does then store it in smallest. if it doesn't then store the heapIndex
		if (left < heapSize && heapSortData[left,selectedColumn] < heapSortData[heapIndex,selectedColumn])
		{
			smallest = left;
		}else
		{
			smallest = heapIndex;
		}
		//Checks if the right index has reached the heap size and checks that the right has the smallest value if it does then store it in smallest. if it doesn't then store the heapIndex
		if (right < heapSize && heapSortData[right,selectedColumn] < heapSortData[smallest,selectedColumn])
		{
			smallest = right;
		}
		//if the smallest is not equal to the heapIndex then perform swaps and call MinHeapify
		if (smallest != heapIndex)
		{
			//sorting  rows based on the sorted column
			for(int column= 0; column <7; column++)
			{	
				double temp = heapSortData[heapIndex,column];
				heapSortData[heapIndex,column] = heapSortData[smallest,column];
				heapSortData[smallest,column] = temp;
			}
			MinHeapify(heapSortData, heapSize, smallest,selectedColumn);
		}
		
	}
}
public class Searching{
	//Counts binary search iterations 
	public static int binarySearchIterations = 0;
	//Counts how many occurences in the linear search 
	public static int linearSearchOccur = 0;
	//Counts how many Linear Search iterations 
	public static int linearSearchIteration = 0;
	//Counts how many occurences in the  binary  hybrid search 
	public static int binaryHybridOccur = 0;
	public static int[] BinarySearchHybrid ( double key, double [,]binaryHybridArray ,int searchColumn,int alreadyFoundIndex)
	{
		int [] occurIndex = new int [1022];//Stores the indexs of each occurence of the key 
		int occurIndexCount = 0;//Stores the index for each occurence
		//Checks if the key has been found 
		if (key == binaryHybridArray[alreadyFoundIndex,searchColumn])
		{
			//Checks the left side of the alreadyFoundIndex index for multiple keys 
			for ( int index = alreadyFoundIndex -1; index >=0;index--)
			{
				//If there is a multiple store it and increment counters 
				if(key == binaryHybridArray[index,searchColumn])
				{
					occurIndex[occurIndexCount] = index;//Stores the index where it was found 
					occurIndexCount++;
					binaryHybridOccur++;
				}else
				{
					//If no more multiple keys then break the loop
					break;
				}
			}
			Array.Sort(occurIndex,0, occurIndexCount);//Sort so  the indexs  are displayed in the correct order 
			//Check the right side of the alreadyFoundIndex index for multiple keys 
			for (int index = alreadyFoundIndex; index <1022; index++)
			{
				//If there is a multiple store it and increment counters 
				if(key == binaryHybridArray[index,searchColumn])
				{
					occurIndex[occurIndexCount] = index;//Stores the index where it was found 
					occurIndexCount++;
					binaryHybridOccur++;
				}else
				{
					break;
				}
			}
		}
		return occurIndex;
	}
	public static int BinarySearch_R(double key, double[,]binarySearchArray, int low, int high, int searchColumn)
	{
		//Check if it has reached the end of the array  and if the data is not found display  error message and return 1 
		if (low >= high)
		{
			Console.WriteLine("Error  Message :Data Not Found");
			return -1;
		} 
		//Calculate the middle
		 int middle = (low + high) / 2;
		 //if key is  in the middle then display message and return middle 
		 if (key == binarySearchArray[middle,searchColumn])
		{
			Console.WriteLine("Found the Data");
			return middle;
		}
		//If key is less than the middle value then use recursion and increment counters 
		if (key < binarySearchArray[middle,searchColumn])
		{
			binarySearchIterations++;//Counts the binary search iterations 
			binaryHybridOccur++;// Counts the number of iterations and occurences for binary search hybrid 
			return BinarySearch_R(key,binarySearchArray, low, middle - 1, searchColumn);
		}
		//If key is greater than the middle value then use recursion and increment counters 
		else 
		{
			binarySearchIterations++;//Counts the binary search iterations 
			binaryHybridOccur++;// Counts the number of iterations and occurences for binary search hybrid 
			return BinarySearch_R(key,binarySearchArray, middle + 1, high ,searchColumn);
		}
	}
	public static int[] LinearSearch(double key , double[,]array , int alreadyFound,int searchColumn)
	{
		linearSearchIteration = 0;//Counts the iterations of linear search 
		linearSearchOccur =0;//Counts the key  occurences of linear search 
		int[] matchedIndex= new int[1022];//Stores the indexs of the occurences that match the key 
		int occurIndex= 0;//Index for the key occurences 
		//Linearly goes through the rows 
		 for (int index = 0; index < 1022;index ++)
		 {
			linearSearchIteration++;//Counts the iterations of linear search
			if ( key == array[index ,searchColumn])
			{
				matchedIndex[occurIndex] = index;
				occurIndex++;
				linearSearchOccur++;//Counts the key  occurences of linear search 
			}
		}
		return matchedIndex;
	}
}


