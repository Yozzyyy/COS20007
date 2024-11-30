#pragma once
#include <string>

class Counter {
private:
    int _count;
    std::string _name;

public:
    Counter(std::string name, int count = 0);

    void Increment();
    void Reset();
    int GetTick() const;
};

