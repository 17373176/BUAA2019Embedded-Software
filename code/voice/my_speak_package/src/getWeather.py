#getWeather.py
import requests

def getweather():
   # print "Hello world"
    r = requests.get('http://www.weather.com.cn/data/cityinfo/101020100.html')
    r.encoding = 'utf-8'
    print r.json()['weatherinfo']["temp1"][0:-1]
    return r.json()['weatherinfo']["temp1"][0:-1],r.json()['weatherinfo']["temp2"][0:-1]
    #return "hello world", "test"
    