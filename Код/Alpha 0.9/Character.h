#pragma once
#include <string>
#include <iostream>
#include <fstream>
#include "Models.h"
using namespace std;

class Characters
{
protected:
	string OS1 = "Windows", OS2 = "MacOS", OS3 = "Linux", OS4 = "ChromeOS";
	string type1 = "PC", type2 = "Laptop", type3 = "Tablet";
	string model;
	int minROM = 1, maxROM = 64;
	int minRAM = 16, maxRAM = 1024;
	int minkernels = 2, maxkernels = 12;
	int minVideoCard = 1, maxVideoCard = 32;
	double minCPU = 1.0, maxCPU = 2.5;
};

class FinalCharacters : protected Characters
{
private:
	string OS, type, model;
	int ROM, RAM, kernels, VideoCard, typeRAM;
	double CPU = 1.5;
public:
	void set(int OS, int type, int ROM, int RAM, int kernels, int VideoCard, double CPU, int profile, string model, int typeRAM)
	{
		if (OS == 1)
			this->OS = OS1;
		else if (OS == 2)
			this->OS = OS2;
		else if (OS == 3 && profile == 2)
			this->OS = OS3;
		else
			this->OS = OS4;
		if (type == 1)
			this->type = type1;
		else if (OS == 2 && CPU == 1.5)
			this->type = type2;
		else if (OS == 2)
			this->type = type1;
		else
			this->type = type3;
		this->ROM = ROM;
		this->RAM = RAM;
		this->kernels = kernels;
		this->VideoCard = VideoCard;
		this->CPU = CPU;
		this->model = model;
		this->typeRAM = typeRAM;
		view(profile);
	}
	void view(int profile)
	{
		ofstream file;
		cout << "Рекомедуемые для Вас характеристики:" << endl;
		cout << "Рекомендованная модель: " << model << endl;
		cout << "Операционная система: " << OS << endl;
		cout << "Вид: " << type << endl;
		cout << "Оперативная память: " << ROM << "GB" << endl;
		if (RAM == 1024)
			cout << "Постоянная память: 1 TB" << endl;
		else
			cout << "Постоянная память: " << RAM << "GB" << endl;
		if (profile == 2)
		{
			cout << "(Для опытных пользователей)" << endl;
			if (typeRAM == 1)
				cout << "Тип памяти HDD" << endl;
			else
				cout << "Тип памяти SSD" << endl;
			cout << "Ядра в процессоре: " << kernels << endl;
			cout << "Частота процессора: " << CPU << endl;
			cout << "Видеопамять: " << VideoCard << "GB" << endl;
		}
		cout << "Так же Вам может подойти: ";
		if (OS == "Windows")
		{
			if (ROM == 8 && RAM == 500 || ROM == 8 && RAM == 1024)
				cout << "Surface Book 2 или MSI";
			else if (ROM == 4 && kernels == 4)
				cout << "Samsung или Xiaomi";
			else if (ROM == 8)
				cout << "Surface Pro 6";
		}
		else if (OS == "MacOS")
		{
			if (ROM == 4)
				cout << "Surface RT";
			else
				cout << "Surface Studio или Surface Studio 2";
		}
		else if (OS == "Linux")
		{
			cout << "Собственная сборка ПК по рекомендованным характеристикам";
		}
		else
		{
			cout << "Планшет на Android или iPad";
		}
		cout << endl;
		file.open("tmp.txt", ostream::app);
		if (!file.is_open())
		{
			cout << "Ошибка открытия файла. Данная рекомендация в файл не будет записана!" << endl;
		}
		else
		{
			cout << "История рекомендуемых характеристик представлены в файле temp.txt" << endl;
			file << "Модель: " << model << endl;
			file << "OS: " << OS << endl;
			file << "Вид: " << type << endl;
			file << "Оперативная память: " << ROM << "GB" << endl;
			if (RAM == 1024)
				file << "Постоянная память: 1TB" << endl;
			else
				file << "Постоянная память: " << RAM << "GB" << endl;
			file << "(Для опытных пользователей)" << endl;
			if (typeRAM == 1)
				file << "Тип памяти HDD" << endl;
			else
				file << "Тип памяти SSD" << endl;
			file << "Ядра в процессоре: " << kernels << endl;
			file << "Частота процессора: " << CPU << endl;
			file << "Видеопамять: " << VideoCard << "GB" << endl;
		}
	}
};

void profileS(int profile);
int questions1(int profile);
int questions2(int profile);
int Smartphone(int data);
int viewphone(int iphone, int winphone, int android, int ROM, int RAM, int kernels, int typeCPU);