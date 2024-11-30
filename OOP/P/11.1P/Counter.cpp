#include "Counter.h"

Counter::Counter(std::string name, int count) : _name(name), _count(count) {}

void Counter::Increment() {
    _count++;
}

void Counter::Reset() {
    _count = 0;
}

int Counter::GetTick() const {
    return _count;
}
