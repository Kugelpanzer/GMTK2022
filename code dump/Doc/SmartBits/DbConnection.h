#include"creator.h"
#include<iostream>
#include <winsock.h>
#include<mysql.h>
#include<fstream>
#include<windows.h>
#pragma once


MYSQL* ConnectToDatabase(std::string databaseName,std::string username, std::string password);
std::vector<textBlock> GetTextBrainDB();

std::string GetIP();

