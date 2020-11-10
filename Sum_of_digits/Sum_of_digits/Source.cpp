#include <vector>
#include <string>
#include <iostream>
using namespace std;

string digits = "9876543210"; // ��������� ����� ����
int needSum = 200; // ����������� �����
int countS = 0; // ���-�� ��������� ��������
vector<int> signs; // ������ ������������ ������

// ������� ������, ���� ����� ������ - �������
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

// ��������� �����, ��� ��� ���������� �����
// ��������� ������ �������� ����� � ������ ������
void parser() {
    string sample = ""; // �������� ������ � ���� ������
    string num = "9";
    vector<int> nums; // ������ �����
    vector<int> signsNew; // ������ ������
    int ind = 1;

    for (int i = 0; i < signs.size(); i++) {
        if (signs[i] == 0) {
            // ����� ���� 9876* ������������, �.�. �������� 
            // ��� �� �������� ������ �����
            if (num == "9876") return; 
            // ������������ �����
            num += digits[ind];
            ind++;
            continue;
        }
        nums.push_back(stoi(num));
        sample += num;
        num = digits[ind];
        ind++;
        // ������������ ������� ������
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

// ���������� ���������� ��� ��������� �����������
// "+", "-" � "" ����� ������� - ������ signs
void check(int ind) {
    // ���� ����� ����������� ����� ����� ������� - ��������� ������
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