
#pragma once
#include "Counter.h"
#include <string>

class Clock {
private:
    Counter _hours;
    Counter _minutes;
    Counter _seconds;

public:
    Clock();

    void Tick();
    void ResetTime();
    std::string CurrentTime() const;
};
