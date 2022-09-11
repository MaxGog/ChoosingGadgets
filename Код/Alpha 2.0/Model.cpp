#include "Character.h"

void mymodel(string* model, int data)
{
	string mymodel;
	if (data == 5)
		mymodel = *model;
	else
		*model = mymodel;
}

void mymodeledit(int OS, int type, int ROM, int RAM, int kernels, int VideoCard, double CPU, int data, string model)
{
	int myOS, mytype, myROM, myRAM, mykernels, myVideoCard;
	double myCPU;
	string mymodel1 = model;
	myOS = OS; mytype = type; myROM = ROM, myRAM = RAM, mykernels = kernels, myVideoCard = VideoCard, myCPU = CPU;
	mymodel(&mymodel1, data);
}
void modelnew()
{
	string model; int OS, type, ROM, RAM, kernels, VideoCard; double CPU; int data;
	cout << "Добро пожаловать в модуль обновления базы данных устройств в программу 'Система поддержки выбора компьютера' . . . " << endl;
	cout << "Загрузка файлов и базы данных . . ." << endl << "На слабых устройствах может загружатся долго . . ." << endl;
	system("pause");
	for (int i = 0; i < 1;)
	{
		cout << "1 - Добавить своё устройство, 2 - Выйти на главное меню: ";
		cin >> data;
		if (data == 2)
			i++;
		else if (data >= 3)
			cout << "Введена неверная команда" << endl;
		else
		{
			cout << "Ввод название модели вводится без пробелов! (На английском)" << endl << "Максимальное добавление моделей 1, так же Вы можете изменить модель, внеснную Вами!" << endl;
			cout << "Введите название Вашей модели компьютера: "; cin >> model;
			cout << "Требуется ввести ввести характеристики модели..." << endl << "Оперативная память (GB): "; cin >> ROM;
			cout << "Постоянной памяти (GB): "; cin >> RAM;
			cout << "Ядра в процессоре: "; cin >> kernels;
			cout << "CPU: "; cin >> CPU;
			cout << "Видеопамять (GB): "; cin >> VideoCard;
			cout << "Тип устройства... 1 - ПК, 2 - Ноутбук, 3 - Планшет: "; cin >> type;
			cout << "Операционная система... 1 - Windows, 2 - Linux: "; cin >> OS; data = 5;
			mymodeledit(OS, type, ROM, RAM, kernels, VideoCard, CPU, data, model);
			for (int j = 0; j < 1;)
			{
				cout << "Хотите что-то изменить? 1 - Да, 2 - Нет: ";
				cin >> data;
				if (data == 2)
					j++;
				else if (data == 1)
				{
					cout << "Название компьютера? 1 - Да, 2 - Нет:"; cin >> data;
					if (data == 1)
					{
						cout << "Введите изменённое название Вашей модели компьютера: "; cin >> model;
					}
					cout << "Оперативная память? 1 - Да, 2 - Нет:  "; cin >> data;
					if (data == 1)
					{
						cout << "Оперативная память: "; cin >> ROM;
					}
					cout << "Постоянной памяти? 1 - Да, 2 - Нет: ";  cin >> data;
					if (data == 1)
					{
						cout << "Введите изменённую память устройства: "; cin >> RAM;
					}
					cout << "Ядра в процессоре? 1 - Да, 2 - Нет: "; cin >> data;
					if (data == 1)
					{
						cout << "Введите изменённые ядра в процессоре: "; cin >> kernels;
					}
					cout << "CPU? 1 - Да, 2 - Нет: "; cin >> data;
					if (data == 1)
					{
						cout << "CPU: "; cin >> CPU;
					}
					cout << "Хотите изменить видеопамять? 1 - Да, 2 - Нет: "; cin >> data;
					if (data == 1)
					{
						cout << "Видеопамять: "; cin >> VideoCard;
					}
					cout << "Тип устройства... 1 - ПК, 2 - Ноутбук, 3 - Планшет: "; cin >> type;
					if (data == 1)
					{
						cout << "Тип устройства... 1 - ПК, 2 - Ноутбук, 3 - Планшет: "; cin >> type;
					}
					cout << "Хотите изменить операционную систему? 1 - Да, 2 - Нет: "; cin >> data;
					if (data == 1)
					{
						cout << "Операционная система... 1 - Windows, 2 - Linux: "; cin >> OS; data = 5;
					}
					mymodeledit(OS, type, ROM, RAM, kernels, VideoCard, CPU, data, model);
				}
			}

		}
	}
}

void models(int OS, int type, int ROM, int RAM, int kernels, int VideoCard, double CPU, int data, string* model)
{
	string modelOS2 = "MacBook Pro", modelOS20 = "MacBook Air"; string modelOS202 = "iMac";
	string modelOS1 = "Surface", modelOS10 = "Lenovo", modelOS101 = "Dell";
	string modelOS4 = "PixelBook";
	string modelOS3 = "Huawei", modelOS30 = "Xiaomi";
	if (OS == 2)
	{
		if (ROM == 4)
			*model = modelOS20;
		else if (ROM >= 8 && CPU == 1.5)
			*model = modelOS2;
		else
			*model = modelOS202;
	}
	else if (OS == 4)
		*model = modelOS4;
	else if (OS == 1)
	{
		setModels(OS, type, ROM, RAM, kernels, VideoCard, CPU, &*model);
	}
	else if (OS == 3)
	{
		if (ROM == 8 && RAM >= 500)
			*model = modelOS3;
		else if (ROM == 4 && RAM <= 500)
			*model = modelOS30;
		else
			mymodel(model, data);
	}
}

struct Base
{
protected:
	string name = ""; string name2 = ""; string name3 = "";
	int OS = 1234;
	int type = 123; int type2 = 123; int type3 = 123;
	int ROM = 64;
	int RAM = 1024;
	int kernels = 8;
	int VideoCard = 6;
	double CPU = 2.9;
};

struct Surface
{
	string name = "Surface Pro"; string name2 = "Surface Laptop"; string name3 = "Surface Studio";
	int OS = 1;
	int type = 3; int type2 = 2; int type3 = 1;
	int ROM = 8; int ROM2 = 16;
	int RAM = 512;
	int kernels = 4;
	int VideoCard = 3;
	double CPU = 2.0;
};

struct Samsung
{
	string name = "Samsung Book S"; string name2 = "Samsung Book Flex";
	int OS = 1;
	int type = 2; int type2 = 2;
	int ROM = 8;
	int RAM = 256; int RAM2 = 512;
	int kernels = 8;
	int VideoCard = 2;
	double CPU = 2.2;
	int typeCPU = 4; int typeCPU2 = 2;
};

struct Lenovo
{
	string name = "Lenovo ideapad"; string name2 = "Lenovo thinkpad"; string name3 = "Lenovo legion";
	int OS = 1;
	int type = 2; int type2 = 3; int type3 = 2;
	int ROM = 4; int ROM2 = 8; int ROM3 = 16;
	int RAM = 1024; int RAM2 = 512; int RAM3 = 64;
	int kernels = 4;
	int VideoCard = 3;
	double CPU = 1.5;
};

int setModels(int OS, int type, int ROM, int RAM, int kernels, int VideoCard, double CPU, string* model)
{
	ofstream mdls;
	int data = 2;
	int fal = 0;
	mdls.open("mdell.xlsx", ostream::app);
	if (!mdls.is_open())
	{
		cout << "Ошибка открытия базы данных... Код ошибки: 0х0004 . . ." << endl;
		fal++;
	}
	else if (data == 2)
	{
		Surface mod1;
		Samsung mod2;
		Lenovo mod3;
		if (ROM == mod1.ROM)
		{
			if (RAM == mod1.RAM)
			{
				if (CPU == mod1.CPU)
				{
					if (type == mod1.type)
						*model = mod1.name;
					else
						*model = mod1.name2;
				}

			}
		}
		else if (ROM == mod1.ROM2)
		{
			if (RAM == mod1.RAM)
			{
				if (CPU == mod1.CPU)
				{
					if (type == mod1.type3)
						*model = mod1.name3;
					else
						*model = mod1.name2;
				}

			}
		}
		else
			mymodel(model, data);
		if (ROM == mod2.ROM)
		{
			if (RAM == mod2.RAM)
			{
				if (CPU == mod2.CPU)
				{
					if (type == mod2.type)
						*model = mod2.name;
					else
						*model = mod2.name2;
				}

			}
			else if (RAM == mod2.RAM2)
			{
				if (CPU == mod2.CPU)
				{
					if (type == mod2.type)
						*model = mod2.name;
					else
						*model = mod2.name2;
				}
			}
		}
		else
			mymodel(model, data);
		if (ROM == mod3.ROM)
		{
			if (RAM == mod3.RAM)
			{
				if (CPU == mod3.CPU)
				{
					if (type == mod3.type)
						*model = mod3.name;
					else
						*model = mod3.name2;
				}

			}
		}
		else
		{
			if (RAM == mod3.RAM)
			{
				if (CPU == mod3.CPU)
				{
					if (type == mod3.type3)
						*model = mod3.name3;
					else
						mymodel(model, data);
				}
			}
		}
	}
	return 0;
}