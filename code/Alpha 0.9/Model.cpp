#include "Models.h"
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
	cout << "Добро пожаловать в модуль обновления базы данных устройств в программу 'Система поддержки выбора компьютера'..." << endl;
	cout << "Загрузка файлов и базы данных..." << endl << "На слабых устройствах может загружатся долго..." << endl;
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
			cout << "Требуется ввести ввести характеристики модели..." << endl << "Оперативная память: "; cin >> ROM;
			cout << "Постоянной памяти: "; cin >> RAM;
			cout << "Ядра в процессоре: "; cin >> kernels;
			cout << "CPU: "; cin >> CPU;
			cout << "Видеопамять: "; cin >> VideoCard;
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
		if (type == 3 && ROM == 8 && RAM == 500 || type == 3 && ROM == 8 && RAM == 1024)
			*model = modelOS1;
		else if (type == 3 || type == 2 && ROM == 4 && kernels == 4)
			*model = modelOS10;
		else if (type == 1 && ROM == 8)
			*model = modelOS101;
		else
		{
			if (type == 3 || type == 2)
				*model = modelOS1;
			/*else
				Models::setModels(OS, type, ROM, RAM, kernels, VideoCard, CPU, model);*/
		}


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