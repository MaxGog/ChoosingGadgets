#include "Character.h"

int Smartphone(int data)
{
	int iphone = 0;
	int winphone = 0;
	int android = 0;
	int ROM = 2, RAM = 8, kernels = 4, typeCPU = 1;

	cout << "Для каких целей Вам требуется смартфон? 1 - Рабочий, 2 - Поседневное использование: ";
	cin >> data;
	if (data == 1)
	{
		winphone = 1;
		cout << "Вам требуется использовать профессиональное программное обеспечение в дороге? 1 - Да, 2 - Нет: ";
		cin >> data;
		if (data == 1)
			iphone = 1;
		cout << "Вам требуется устанавливать программы от Вашей месты работы? 1 - Да, 2 - Нет: ";
		cin >> data;
		if (data == 1)
			iphone = 0; android = 1;
	}
	else
	{
		iphone = 1;
		android = 1;
		cout << "Вы будете использовать смартфон один, или ещё будут использовать Ваши члены семьи? 1 - Один, 2 - Все: ";
		cin >> data;
		if (data == 2)
			iphone = 1;
	}
	cout << "Вы работаете с файловой системой? 1 - Да, 2 - Нет: ";
	cin >> data;
	if (data == 1)
	{
		winphone = 1;
		android = 1;
		iphone = 0;
		RAM = 16;
		ROM = 2;
		cout << "Вы используете файлы автономно, или в облаке? 1 - Автономно, 2 - В облаке: ";
		cin >> data;
		if (data == 2)
			iphone = 1;
	}
	cout << "Сколько приложений Вы одновременно будете использовать? 1 - 1, 2 - 2, 3 - 3, 4 - 4<: ";
	cin >> data;
	if (data == 1)
	{
		if (iphone == 0)
			iphone = 0;
		else
			iphone = 1;
		ROM = 2; android = 1; winphone = 1;
	}
	else if (data == 2)
	{
		iphone = 0;
		ROM = 3; android = 1; winphone = 1;
	}
	else if (data == 3)
	{
		iphone = 0;
		ROM = 3; android = 1; winphone = 1;
	}
	else
	{
		iphone = 0;
		ROM = 4; android = 1; winphone = 1;
	}
	cout << "Вам требуется надёжная защита данных? 1 - Да, 2 - Нет: ";
	cin >> data;
	if (data == 1)
	{
		if (iphone == 0)
			iphone = 0;
		else
			iphone = 1;
		winphone = 0; android = 1;
	}
	cout << "Вы будете устанавливать более 20 сторонних приложений? 1 - Да, 2 - Нет: ";
	cin >> data;
	if (data == 1)
	{
		cout << "Вам требуется доступ к приложениям из интернета? 1 - Да, 2 - Нет: ";
		cin >> data;
		if (data == 1)
			android = 1, iphone = 0, winphone = 1;
		RAM = 64; ROM = 4; kernels = 6;
	}
	cout << "Будете использовать мобильные VR гарнитуры? 1 - Да, 2 - Нет: ";
	cin >> data;
	if (data == 1)
	{
		winphone = 0; android = 1; iphone = 0; typeCPU = 2;
	}
	cout << "Вы будете играть на телефоне в тяжёлые игры? 1 - Да, 2 - Нет: ";
	cin >> data;
	if (data == 1)
	{
		if (winphone == 1)
			winphone = 1;
		else
			winphone = 0;
		android = 1; iphone = 1; typeCPU = 2; ROM = 6; RAM = 128;
	}
	viewphone(iphone, winphone, android, ROM, RAM, kernels, typeCPU);
	return 0;
}

int viewphone(int iphone, int winphone, int android, int ROM, int RAM, int kernels, int typeCPU)
{
	int data;
	if (iphone == 1 && android == 1)
	{
		cout << "Синхронизируете ли Вы Ваш смартфон с другим устройством? 1 - Да, 2 - Нет: ";
		cin >> data;
		if (data == 1)
		{
			cout << "1 - ПК с Windows, 2 - Продукты Apple: ";
			cin >> data;
			if (data == 1)
				iphone = 0;
			else
				android = 0;
		}
		else
			iphone = 0;
	}
	else if (android == 1 && winphone == 1)
	{
		cout << "Вам требуется режим Desktop на телефоне? 1 - Да, 2 - Нет: ";
		cin >> data;
		if (data == 1)
			android = 0;
		else
			winphone = 0;
	}
	else
	{
		cout << "Синхронизируете ли Вы Ваш смартфон с другим устройством? 1 - Да, 2 - Нет: ";
		cin >> data;
		if (data == 1)
		{
			cout << "1 - ПК с Windows, 2 - Продукты Apple: ";
			cin >> data;
			if (data == 1)
				iphone = 0;
			else
				winphone = 0;
		}
		else
			iphone = 0;
	}
	cout << "Рекомендуемый для Вас смартфон: " << endl;
	if (android == 1)
	{
		cout << "Лучше всего для Вас подходит Google Pixel, или другой смартфон с операционной системой ANDROID" << endl;
		cout << "Оперативная память: " << ROM << "GB" << endl;
		cout << "Постоянная память: " << RAM << "GB" << endl;
		if (typeCPU == 2)
			cout << "Тип архитекруты процессора: ARMx64" << endl;
		else
			cout << "Тип архитекруты процессора: ARMx86" << endl;
		cout << "Ядра в процессоре: " << kernels << endl;
	}
	else if (winphone == 1)
	{
		cout << "Лучше всего вам подойдёт: ";
		if (ROM >= 3)
			cout << "Microsoft Limua 950 XL" << endl;
		else
			cout << "Microsoft Limua 650" << endl;
		cout << "Оперативная память: " << ROM << endl;
		cout << "Постоянная память: " << RAM << endl;
		if (typeCPU == 2)
			cout << "Тип архитекруты процессора: ARMx64" << endl;
		else
			cout << "Тип архитекруты процессора: ARMx86" << endl;
		cout << "Ядра в процессоре: " << kernels << endl;
	}
	else
	{
		cout << "Вам лучше всего подойдёт iPhone" << endl;
		cout << "Оперативная память: ";
		if (ROM <= 1 && ROM >= 3)
			cout << 2 << "GB" << endl;
		else if (ROM <= 3 && ROM >= 6)
			cout << 4 << "GB" << endl;
		cout << "Постоянная память: " << RAM << "GB" << endl;
		if (typeCPU == 2)
			cout << "Тип архитекруты процессора: ARMx64" << endl;
		else
			cout << "Тип архитекруты процессора: ARMx86" << endl;
		cout << "Ядра в процессоре: " << kernels << endl;
	}
	return 0;
}
