#include <vector>
#include <string>
#include <iostream>
using namespace std;

string digits = "9876543210"; // начальный набор цифр
int needSum = 200; // необходимая сумма
int countS = 0; // кол-во найденных примеров
vector<int> signs; // массив перестановки знаков

// считает пример, если сумма нужная - выводит
void calc(string& sample, vector<int>& nums, vector<int>& signsNew) {
    int sum = nums[0];
    for (int i = 0; i < signsNew.size(); i++) {
        if (signsNew[i] == 1) {
            sum += nums[i + 1];
        }
        if (signsNew[i] == 2) {
            sum -= nums[i + 1];
        }
    }
    if (sum == needSum) {
        cout << sample;
        cout << " = " << sum << "\n";
        countS += 1;
    }
}

// соединяет цифры, где они составляют число
// формирует массив итоговых чисел и массив знаков
void parser() {
    string sample = ""; // итоговый пример в виде строки
    string num = "9";
    vector<int> nums; // массив чисел
    vector<int> signsNew; // массив знаков
    int ind = 1;

    for (int i = 0; i < signs.size(); i++) {
        if (signs[i] == 0) {
            // числа вида 9876* пропускаются, т.к. очевидно 
            // они не составят нужное число
            if (num == "9876") return; 
            // формирование числа
            num += digits[ind];
            ind++;
            continue;
        }
        nums.push_back(stoi(num));
        sample += num;
        num = digits[ind];
        ind++;
        // формирование массива знаков
        if (signs[i] == 1) {
            signsNew.push_back(1);
            sample += " + ";
        }
        else {
            signsNew.push_back(2);
            sample += " - ";
        }
    }
    nums.push_back(stoi(num));
    sample += num;
    calc(sample, nums, signsNew);
}

// рекурсивно генерирует все возможные расстановки
// "+", "-" и "" между цифрами - массив signs
void check(int ind) {
    // если знаки расставлены между всеми цифрами - разбираем пример
    if (ind == digits.size() - 1) {
        parser();
        return;
    }
    signs.push_back(0); // ""
    check(ind + 1);

    signs.pop_back();
    signs.push_back(1); // "+"
    check(ind + 1);

    signs.pop_back();
    signs.push_back(2); // "-"
    check(ind + 1);
    signs.pop_back();
}
              
int main() {
    check(0);
    cout << "Founded " << countS << " samples" << "\n";
}