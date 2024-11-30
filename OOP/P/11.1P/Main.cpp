#include <iostream>
#include <thread>
#include <chrono>
#include "Clock.h"

int main() {
    Clock clock;

    for (int i = 0; i < 86400; ++i) { // Simulate a full day (86400 seconds)
        std::this_thread::sleep_for(std::chrono::seconds(1)); // Wait for 1 second
        system("CLS"); // Clear the console (works on Windows)
        clock.Tick();
        std::cout << clock.CurrentTime() << std::endl;
    }

    return 0;
}
