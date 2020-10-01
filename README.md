
# Name Sorter

## Introduction

This is an application where the user can sort a set of names, order that set by last name first, then by any given names the person may have.
A name must have at least 1 given name and may have up to 3 given names

## Objectives

This application  is able to sort the list of names correctly.

I designed the structure for this application base on my knowledge with few software principals such as SOLID, Seperate of concern and adapt some non-functional requirements such as:

1. Maintainability.
2. Readability.
3. Testability.
4. Performance.
5. Extendability.

## How Far Did I Get?

I completed the test's requirements.

## Technologies & Sorting Algorithm

.Net Core, MSTest, NBuilder, Merge Sort (Top-down).

## How to build code

  1. Clone the repository (skip this step if you have the application on your machine)
  
  
  2. At the root directory contains application's solution , restore required packages by running:
     ```
     dotnet restore
     ```
  3. Next, build the solution by running:
     ```
     dotnet build
     ```
  4. Next, within the `NameSorterApplication\NameSorterApplication` directory, launch the console application by running:
     ```
     dotnet run
     ```
     
  5. (Optional) Incase you want to run the unit testing, within the `NameSorterApplication\NameSorter.Test` directory, launch the test application by running:
     ```
     dotnet test
     ```
     
Note: If you want to modify unsorted data please open the `unsorted-names-list.txt` file and update it. After that you need to re-build and run the application again.

## Documents

The idea of the structure in this application is seperated the sorting logic and comparing logic in different classes so, these classes will be easy to maintain, test and extend. The merging method doesn't depend on the comparing logic detail, it only depends on the interface.

### INameComparer<>

This interface represents for name comparing.

### ISorter<>

This interface represents for name sorting.

### IFilerHelper<>

This interface represents for read and write file.

## Testing

I have created some test cases for the sorting class. Besides, I also added an integration test to test the whole application and the perfomance (500,000 records).

## Biggest Challenges

- Research sorting algorithms (QuickSort, HeapSort, MergeSort). The reason why I decided to use MergeSort is because the Merge has a good time complexity and the stablebility which either QuickSort or HeapSort don't have both. 

- Decided which sorting algorithm is the best one to achive the assignment's requirements.

- Understand the MergeSort algorithm.

## Improvements
There are many improvement for this application following below:

+ Creating more unit test for this application. Such as: Comparer, FileHelper.

+ Creating the configuration file for this application.

+ Improving the performance of the application.

 
Thanks for reading this.;)


