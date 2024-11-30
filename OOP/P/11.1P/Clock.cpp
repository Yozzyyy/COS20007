#include "Clock.h"
#include <iomanip>
#include <sstream>

Clock::Clock() : _hours("hours"), _minutes("minutes"), _seconds("seconds") {}

void Clock::Tick() {
    _seconds.Increment();
    if (_seconds.GetTick() > 59) {
        _seconds.Reset();
        _minutes.Increment();
        if (_minutes.GetTick() > 59) {
            _minutes.Reset();
            _hours.Increment();
            if (_hours.GetTick() > 23) {
                ResetTime();
            }
        }
    }
}

void Clock::ResetTime() {
    _hours.Reset();
    _minutes.Reset();
    _seconds.Reset();
}

std::string Clock::CurrentTime() const {
    std::ostringstream timeStream;
    timeStream << std::setw(2) << std::setfill('0') << _hours.GetTick() << ":"
        << std::setw(2) << std::setfill('0') << _minutes.GetTick() << ":"
        << std::setw(2) << std::setfill('0') << _seconds.GetTick();
    return timeStream.str();
}
