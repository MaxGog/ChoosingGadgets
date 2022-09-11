#include "Character.h"
#include "Models.h"

void profileS(int profile)
{
	if (profile == 1)
		questions1(profile);
	else if (profile == 2)
		questions2(profile);
	else
		cout << "Введена неверная цифра. Прошу, повторите попытку..." << endl;
}

int questions1(int profile)
{
	FinalCharacters job;
	int OS = 1234, type = 123, ROM = 2, RAM = 16, kernels = 4, VideoCard = 1, data, games = 2, typeRAM = 1;
	double CPU = 1.5;
	string model;
	cout << "Для каких целей требуется Вам компьютер? 1 - Дома, 2 - Работы, 3 - Развлечений, 4< = Незнаю: ";
	cin >> data;
	if (data == 2)
	{
		OS = 124; type = 23; ROM = 4; RAM = 200;
		cout << "Планируете ли Вы работать с офисными программами? 1 - Да, 2 - Нет: ";
		cin >> data;
		if (data == 1)
			OS = 1; type = 2;
	}
	else if (data == 1)
	{
		OS = 134; RAM = 64; ROM = 2;
	}
	else if (data == 3)
	{
		OS = 13; ROM = 6; RAM = 200;
		cout << "Планируете ли Вы играть в тяжёлые игры? 1 - Да, 2 - Нет: ";
		cin >> games;
		if (games == 1)
			ROM = 8; RAM = 500;
	}
	/*else if (data == 16032005)
	{
		{
			int i;
			int niz = 205, nlugol = 200, npugol = 188;
			int stena = 186, vnyt = 253;
			int trava = 178, vozd = 176;
			int vlugol = 187, vpugol = 201;
			int kl = 47, kp = 92;
			{
				for (i = 0; i < 14; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(kl);
				cout << static_cast<char>(kp);
				for (i = 0; i < 14; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 13; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(kl);
				for (i = 0; i < 2; i++)
				{
					cout << " ";
				}
				cout << static_cast<char>(kp);
				for (i = 0; i < 13; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 12; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(kl);
				for (i = 0; i < 4; i++)
				{
					cout << " ";
				}
				cout << static_cast<char>(kp);
				for (i = 0; i < 12; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 11; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(kl);
				for (i = 0; i < 6; i++)
				{
					cout << " ";
				}
				cout << static_cast<char>(kp);
				for (i = 0; i < 11; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 10; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(kl);
				for (i = 0; i < 8; i++)
				{
					cout << " ";
				}
				cout << static_cast<char>(kp);
				for (i = 0; i < 10; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 9; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(kl);
				for (i = 0; i < 10; i++)
				{
					cout << " ";
				}
				cout << static_cast<char>(kp);
				for (i = 0; i < 9; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 8; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(kl);
				for (i = 0; i < 12; i++)
				{
					cout << " ";
				}
				cout << static_cast<char>(kp);
				for (i = 0; i < 8; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 7; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(kl);
				for (i = 0; i < 14; i++)
				{
					cout << " ";
				}
				cout << static_cast<char>(kp);
				for (i = 0; i < 7; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 6; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(kl);
				for (i = 0; i < 16; i++)
				{
					cout << " ";
				}
				cout << static_cast<char>(kp);
				for (i = 0; i < 6; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(kl);
				for (i = 0; i < 18; i++)
				{
					cout << " ";
				}
				cout << static_cast<char>(kp);
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 4; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(kl);
				for (i = 0; i < 20; i++)
				{
					cout << " ";
				}
				cout << static_cast<char>(kp);
				for (i = 0; i < 4; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 3; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(kl);
				for (i = 0; i < 22; i++)
				{
					cout << " ";
				}
				cout << static_cast<char>(kp);
				for (i = 0; i < 3; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 2; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(kl);
				for (i = 0; i < 24; i++)
				{
					cout << " ";
				}
				cout << static_cast<char>(kp);
				for (i = 0; i < 2; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 2; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(niz);
				cout << static_cast<char>(niz);
				cout << static_cast<char>(niz);
				cout << static_cast<char>(vlugol);
				for (i = 0; i < 18; i++)
				{
					cout << static_cast<char>(vnyt);
				}
				cout << static_cast<char>(vpugol);
				cout << static_cast<char>(niz);
				cout << static_cast<char>(niz);
				cout << static_cast<char>(niz);
				for (i = 0; i < 2; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(stena);
				for (i = 0; i < 18; i++)
				{
					cout << static_cast<char>(vnyt);
				}
				cout << static_cast<char>(stena);
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(stena);
				for (i = 0; i < 18; i++)
				{
					cout << static_cast<char>(vnyt);
				}
				cout << static_cast<char>(stena);
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(stena);
				for (i = 0; i < 18; i++)
				{
					cout << static_cast<char>(vnyt);
				}
				cout << static_cast<char>(stena);
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(stena);
				for (i = 0; i < 18; i++)
				{
					cout << static_cast<char>(vnyt);
				}
				cout << static_cast<char>(stena);
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(stena);
				for (i = 0; i < 18; i++)
				{
					cout << static_cast<char>(vnyt);
				}
				cout << static_cast<char>(stena);
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(stena);
				for (i = 0; i < 18; i++)
				{
					cout << static_cast<char>(vnyt);
				}
				cout << static_cast<char>(stena);
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(stena);
				for (i = 0; i < 18; i++)
				{
					cout << static_cast<char>(vnyt);
				}
				cout << static_cast<char>(stena);
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(stena);
				for (i = 0; i < 18; i++)
				{
					cout << static_cast<char>(vnyt);
				}
				cout << static_cast<char>(stena);
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(stena);
				for (i = 0; i < 18; i++)
				{
					cout << static_cast<char>(vnyt);
				}
				cout << static_cast<char>(stena);
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			{
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << static_cast<char>(nlugol);
				for (i = 0; i < 18; i++)
				{
					cout << static_cast<char>(niz);
				}
				cout << static_cast<char>(npugol);
				for (i = 0; i < 5; i++)
				{
					cout << static_cast<char>(vozd);
				}
				cout << endl;
			}
			cout << endl;
		}
	}*/
	cout << "Вы часто передвигаетесь с гаджетами? 1 - Да, 2 - Нет: ";
	cin >> data;
	if (data == 1)
		type = 3;
	else
		type = 2;
	cout << "Планируете работать с профессиональным программным обеспечением? 1 - Да, 2 - Нет: ";
	cin >> data;
	if (data == 1)
	{
		if (OS == 134 || OS == 13)
			OS = 123;
		else
			OS = 1;
		ROM = 6; RAM = 500; type = 1;
		cout << "Планируете использовать Photoshop или Premiere Pro? 1 - Да, 2 - Нет: ";
		cin >> data;
		if (data == 1)
		{
			ROM = 8, RAM = 500; CPU = 2.5; kernels = 8; VideoCard = 4;
		}
	}
	cout << "Планируете ли Вы хранить большой объём информации? 1 - Да, 2 - Нет: ";
	cin >> data;
	if (data == 1)
		RAM = 1024;
	cout << "Вы синхронизируете Ваши устройства? 1 - Да, 2 - Нет: ";
	cin >> data;
	if (data == 1)
	{
		cout << "У Вас какой смартфон? 1 - Android, 2 - iPhone, 3 - Windows Phone: ";
		cin >> data;
		if (data == 1 || data == 3)
			OS = 1;
		else if (data == 2)
			OS = 2;
		if (RAM != 1024)
			RAM = 500;
		if (OS == 2 && ROM != 8)
			ROM = 4;
	}
	if (OS > 9)
	{
		cout << "Вам требуется бюджетное устройство? 1 - Да, 2 - Нет: ";
		cin >> data;
		if (data == 1)
		{
			if (OS != 12)
			{
				OS = 3; ROM = 2; RAM = 200;
			}
			else
				OS = 2; ROM = 4; RAM = 500;
		}
		else
			OS = 1;

	}
	if (OS == 2 && data != 1)
		type = 2; ROM = 8; RAM = 1024;
	if (games == 1 && type == 2)
	{
		ROM = 8; RAM = 500; kernels = 8; OS = 1; VideoCard = 2; type = 1;
	}
	else if (games == 1 && type == 3)
	{
		ROM = 8; RAM = 500; kernels = 8; OS = 1; VideoCard = 2; type = 2;
	}
	models(OS, type, ROM, RAM, kernels, VideoCard, CPU, data, &model);
	job.set(OS, type, ROM, RAM, kernels, VideoCard, CPU, profile, model, typeRAM);
	return 0;
}

int questions2(int profile)
{
	FinalCharacters job;
	int OS = 1234, type = 123, ROM = 2, RAM = 16, kernels = 4, VideoCard = 1, data, game = 2, typeRAM = 1;
	double CPU = 1.5;
	string model;
	cout << "Для каких целей требуется Вам компьютер? 1 - Дома, 2 - Работы, 3 - Развлечений, 4< = Незнаю: ";
	cin >> data;
	if (data == 2)
	{
		OS = 12; type = 23;  ROM = 4; RAM = 200;
		cout << "Планируете ли Вы работать с офисными программами? 1 - Да, 2 - Нет: ";
		cin >> data;
		if (data == 1)
			OS = 1; type = 2;
	}
	else if (data == 1)
	{
		OS = 134; ROM = 2; RAM = 64;
	}
	else if (data == 3)
	{
		kernels = 6; CPU = 2.0; RAM = 200; ROM = 6; OS = 13;
		cout << "Планируете ли Вы играть в тяжёлые игры? 1 - Да, 2 - Нет: ";
		cin >> game;
		if (game == 1)
			ROM = 8; RAM = 500; kernels = 8; OS = 1; VideoCard = 2; type = 1; typeRAM = 2;
	}
	cout << "Вы часто передвигаетесь с гаджетами? 1 - Да, 2 - Нет: ";
	cin >> data;
	if (data == 1)
		type = 3;
	cout << "Планируете работать с профессиональным программным обеспечением? 1 - Да, 2 - Нет: ";
	cin >> data;
	if (data == 1)
	{
		if (OS == 134 || OS == 13)
			OS = 123;
		else if (OS == 1)
			OS = 1;
		ROM = 8; RAM = 500; CPU = 2.0; kernels = 6; VideoCard = 4;
		if (type == 3)
			type = 2;
		cout << "Планируете использовать Photoshop или Premiere Pro? 1 - Да, 2 - Нет: ";
		cin >> data;
		if (data == 1)
		{
			OS = 2, ROM = 8, RAM = 500; CPU = 2.5; kernels = 8; VideoCard = 4; typeRAM = 2;
		}
		cout << "Планируете работать с 3D графикой? 1 - Да, 2 - Нет: ";
		cin >> data;
		if (data == 1)
			VideoCard = 4; typeRAM = 2;
		cout << "Планируете работать с VR? 1 - Да, 2 - Нет: ";
		cin >> data;
		if (data == 1)
		{
			kernels = 8; VideoCard = 4; ROM = 16; RAM = 1024; typeRAM = 2;
		}
	}
	cout << "Планируете ли Вы хранить большой объём информации? 1 - Да, 2 - Нет: ";
	cin >> data;
	if (data == 1)
		RAM = 1024; typeRAM = 2;
	cout << "Собираетесь ли Вы расширять дисплей? 1 - Да, 2 - Нет: ";
	cin >> data;
	if (data == 1)
	{
		if (ROM >= 6)
			ROM = 6;
		if (type == 23 || type == 3)
			type = 2;
	}
	cout << "Вы синхронизируете Ваши устройства? 1 - Да, 2 - Нет: ";
	cin >> data;
	if (data == 1)
	{
		cout << "У Вас какой смартфон? 1 - Android, 2 - iPhone, 3 - Windows Phone: ";
		cin >> data;
		if (data == 1 || data == 3)
			OS = 1;
		else if (data == 2)
			OS = 2;
		if (RAM != 1024)
			RAM = 500;
		if (OS == 2 && ROM <= 8)
			ROM = 4;
	}
	cout << "Вам требуется компилировать или тестировать программное обесечение? 1 - Да, 2 - Нет: ";
	cin >> data;
	if (data == 1)
	{
		if (RAM != 500 && CPU != 2.5 && kernels != 8 && VideoCard != 4)
			RAM = 500; CPU = 2.5; kernels = 8; VideoCard = 4; typeRAM = 2;
		if (ROM > !8)
			ROM = 8; typeRAM = 2;
	}
	if (OS > 9)
	{
		cout << "Вам требуется свободное программное обеспечение? 1 - Да, 2 - Нет: ";
		cin >> data;
		if (data == 1)
		{
			if (OS <= 12 && OS >= 13)
				OS = 3;
			else
			{
				cout << "Свободное программное обеспечение нужно с лицензией? 1 - Да, 2 - Нет: ";
				cin >> data;
				if (data == 1)
					OS = 4;
				else
					OS = 1;
			}
		}
		else
		{
			OS = 1;
		}
	}
	if (OS == 2)
		type = 2; RAM = 1024;
	if (game == 1 && type == 2)
	{
		ROM = 16; RAM = 500; kernels = 8; OS = 1; VideoCard = 2; type = 1;
	}
	else if (game == 1 && type == 3)
	{
		ROM = 16; RAM = 500; kernels = 8; OS = 1; VideoCard = 2; type = 2;
	}
	models(OS, type, ROM, RAM, kernels, VideoCard, CPU, data, &model);
	job.set(OS, type, ROM, RAM, kernels, VideoCard, CPU, profile, model, typeRAM);
	return 0;
}