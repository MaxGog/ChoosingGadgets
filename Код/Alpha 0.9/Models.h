#pragma once
#include <string>
#include <iostream>
#include <fstream>
#include "Character.h"
using namespace std;

//class Models
//{
//private:
//	string OS, type, model;
//	int ROM, RAM, kernels = 4, VideoCard = 1, fal = 0;
//	double CPU = 1.5;
//public:
//	Models(int OS, int type, int ROM, int RAM, int kernels, int VideoCard, double CPU, string model);
//	int setModels(int OS, int type, int ROM, int RAM, int kernels, int VideoCard, double CPU, string model)
//	{
//
//	}
//};
//
//Models::Models(int OS, int type, int ROM, int RAM, int kernels, int VideoCard, double CPU, string model)
//{
//	ofstream mdls;
//	int data = 2;
//	mdls.open("mdell.xlsx", ostream::app);
//	if (!mdls.is_open())
//	{
//		cout << "Ошибка открытия базы данных..." << endl;
//		fal++;
//	}
//	if (data == 2)
//	{
//
//	}
//}

void models(int OS, int type, int ROM, int RAM, int kernels, int VideoCard, double CPU, int data, string* model);
void mymodel(string* model, int data);
void mymodeledit(int OS, int type, int ROM, int RAM, int kernels, int VideoCard, double CPU, int data, string model);
void modelnew();
void models(int OS, int type, int ROM, int RAM, int kernels, int VideoCard, double CPU, int data, string* model);

//struct Surface
//{
//protected:
//	string name = "Surface Pro";
//	string name2 = "Surface Laptop";
//	string name3 = "Surface Studio";
//	int OS = 1;
//	int type = 3;
//	int type2 = 2;
//	int type3 = 1;
//	int ROM = 8;
//	int ROM2 = 16;
//	int RAM = 512;
//	int kernels = 4;
//	int VideoCard = 3;
//	double CPU = 2.0;
//};