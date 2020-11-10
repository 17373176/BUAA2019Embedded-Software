g++ -shared -fPIC -o libnavi.so navigation.cpp
nm -D libnavi.so | grep self
sudo cp libnavi.so /lib/libnavi.so
