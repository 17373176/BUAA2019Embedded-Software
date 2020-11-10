#ifndef VOICE_CMD_H_INCLUDED
#define VOICE_CMD_H_INCLUDED

extern "C"{
    char* broadCastWeather();
    void broadCastAny(char* word);
    char* getVoiceInstr();
}
#endif // VOICE_CMD_H_INCLUDED
