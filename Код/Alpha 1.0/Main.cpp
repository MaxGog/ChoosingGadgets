#include "Character.h"

int main()
{
	setlocale(LC_ALL, "Russian");
	int profile;
	int data;
	cout << "Добро пожаловать в систему поддержки выбора устройства!" << endl;
	cout << "Данная программа Вам поможет выбрать подходящее устройство для использования..." << endl;
	for (int j = 0; j < 1;)
	{
		cout << "1 - Войти в поддержку, 2 - "/*Внести новые модели компьютера*/"(ERROR), 3 - Информация, 4 - Выйти: ";
		cin >> data;
		if (data == 1)
		{
			cout << "1 - Домашние или рабочие компьютеры, 2 - Смартфоны, 3 - VR гарнитуры: ";
			cin >> data;
			if (data == 1)
			{
				for (int i = 0; i < 1;)
				{
					cout << "1 - Стандартный пользователь, 2 - Опытный пользователь: ";
					cin >> profile;
					profileS(profile);
					if (profile == 1 || profile == 2)
					{
						cout << "Выйти на главное меню? 1 - Да, 2 - Нет: ";
						cin >> data;
						if (data == 1)
							i++;
					}
				}
			}
			else if (data == 2)
			{
				for (int i = 0; i < 1;)
				{
					Smartphone(data);
					cout << "Выйти на главное меню? 1 - Да, 2 - Нет: ";
					cin >> data;
					if (data == 1)
						i++;
				
				}
			}
			else if (data == 3)
			{
				for (int i = 0; i < 1;)
				{
					VR(data);
					cout << "Выйти на главное меню? 1 - Да, 2 - Нет: ";
					cin >> data;
					if (data == 1)
						i++;

				}
			}
			else
				cout << "Введён неправильный выбор. Попробуйте ещё раз..." << endl << endl;

		}
		else if (data == '/')
			cout << "Ошибка ввода. Введите другое значение..." << endl;
		else if (data == 2)
			modelnew();
		else if (data == 3)
		{
			cout << endl << "Разработчик Гоглов Максим Алексеевич (MaxHorror5993);" << endl;
			cout << "Программа написана под OC Microsoft Windows (Win32) (от версии 2004, x64) на языке C++. На остальных версиях OC Microsoft Windows может работать некоректно." << endl;
			cout << "Программа является бесплатной с открытым исходным кодом во время разработки;" << endl << "Выпуск программы является платной на коммерческие организации." << endl;
			cout << "Минимальные характеристики для программного обеспечения: " << endl << "ROM = 200MB, RAM = 100MB + 30KB, CPU = 0.5" << endl << "ОБЯЗАТЕЛЬНОЕ НАЛИЧИЕ: Microsoft Visual C++ Restributable 2015-2019" << endl;
			cout << "Программа является консольным приложением. Для изменения интерфейса зайдите в настройки консоли Microsoft Windows или MS DOC." << endl;
			cout << "Лицензия RTM (Отдельно) - Debug (Alpha 1.0)" << endl << endl << "MaxHorror5993 PCsupport. Copyright (R)." << endl << endl << endl << endl;
		}
		else if (data == 4)
			j++;
		else if (data >= 5)
			cout << "Введена неверная команда..." << endl;
	}
	system("pause");
	return 0;
}