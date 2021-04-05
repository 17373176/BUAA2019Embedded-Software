/*
Navicat SQL Sever Data Transfer

Source Server         : localhost
Source Host           : localhost:44354
Source Database       : qizhi

Target Server Type    : SQL Sever
File Encoding         : 65001

Author                : YE JINGBO
Database name		  : qizhi
User name             : sa
Password              : 123456Rt
Date: 2020-4-22 16:37:48
*/

--SET FOREIGN_KEY_CHECKS 0;

-- ----------------------------
-- Table structure for t_instr 表-指令
-- ----------------------------
---DROP TABLE IF EXISTS t_instr;

CREATE TABLE t_instr (
  I_NO int NOT NULL identity(0, 1), /* 自动增长 */
  I_KeyWord varchar(255) NOT NULL,
  I_TYPE varchar(255) NOT NULL,
  PRIMARY KEY (I_NO)
)

-- ----------------------------
-- Table structure for t_user 表-用户信息
-- ----------------------------
--DROP TABLE IF EXISTS t_user;

CREATE TABLE t_user (
  U_NO int NOT NULL  identity(0, 1), /* 自动增长 */
  U_USERNAME varchar(255) unique NOT NULL,
  U_PASSWORD varchar(255) NOT NULL,
  U_ID varchar(255) unique NOT NULL,
  U_TYPE bit NOT NULL, /* false代表用户，true代表管理员*/
  PRIMARY KEY(U_NO)
)

-- ----------------------------
-- Table structure for t_task 表-任务
-- ----------------------------
--DROP TABLE IF EXISTS t_task;
CREATE TABLE t_task (
  T_NO int NOT NULL identity(0, 1), /* 自动增长 */
  T_U_NO int NOT NULL, /*每个任务都有对应的用户no*/
  T_I_NO int NOT NULL, /*每个任务都有对应的指令no*/
  T_IS_FINISHED int NOT NULL, /*是否完成*/
  T_TIME datetime NOT NULL, /*任务时间*/
  PRIMARY KEY(T_NO),
  FOREIGN KEY(T_I_NO) REFERENCES t_instr,
  FOREIGN KEY(T_U_NO) REFERENCES t_user
)

-- ----------------------------
-- Table structure for t_net 表-网络天气
-- ----------------------------
--DROP TABLE IF EXISTS t_net;
CREATE TABLE t_net (
  N_NO int NOT NULL identity(0, 1), /* 自动增长 */
  N_DATE varchar(255) NOT NULL,
  N_INFORM varchar(255) NOT NULL,
  PRIMARY KEY(N_NO),
)