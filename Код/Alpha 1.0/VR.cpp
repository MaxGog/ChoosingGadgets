#include "Character.h"

int VR(int data)
{
	int VR;
	cout << "Для каких целей Вам требуется VR гарнитура? 1 - Дома, 2 - Работы: ";
	cin >> data;
	if (data == 1)
	{
		cout << "Какие сервисы Вы будете использовать? 1 - Windows Mixed Reality, 2 - SteamVR, 3 - Google VR: ";
		cin >> data;
		if (data == 1 || data == 2)
			VR = 1;
		else
			VR = 2;
	}
	else
	{
		VR = 3;
	}
	viewVR(VR);
	return 0;
}

int viewVR(int VR)
{
	if (VR == 1)
	{
		cout << "Вам подойдёт гарнитура VR от компаний Lenovo, HTC и Asus (Acer)" << endl;
	}
	else if (VR == 2)
	{
		cout << "Вам подойдёт портативная гарнитура VR от Google (Cardboard или Daydream)" << endl;
	}
	else
		cout << "Вам нужен Microsoft Hololens" << endl;
	return 0;
}