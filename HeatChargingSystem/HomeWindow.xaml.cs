﻿using HeatChargingSystem.api;
using HeatChargingSystem.model;
using HeatChargingSystem.model.request;
using HeatChargingSystem.model.response;
using HeatChargingSystem.utils;
using HeatChargingSystem.view;
using HeatChargingSystem.view.homeAction;
using Panuon.UI.Silver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Management;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Xml;

namespace HeatChargingSystem
{
    /// <summary>
    /// HomeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class HomeWindow : WindowX
    {
        public HomeWindow()
        {
            InitializeComponent();
            this.Loaded += HomeWindow_Loaded;
        }

        private void HomeWindow_Loaded(object sender, RoutedEventArgs e)
        {
         
           
            this.DataContext = new HomeViewModel();
        }


        ResponseUserInfoModel userInfoModel;


        /// <summary>
        /// 设置读写卡端口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingCardPortEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            SettingCardPortWindow window = new SettingCardPortWindow();
            this.IsMaskVisible = true;
            window.ShowDialog();
            this.IsMaskVisible = false;
        }
        /// <summary>
        /// 收费站收费标准
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingChargeLevelBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            SettingChargeLevelWindow window = new SettingChargeLevelWindow();
            this.IsMaskVisible = true;
            window.ShowDialog();
            this.IsMaskVisible = false;
        }
        /// <summary>
        /// 修改默认收费开始日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingChargeTimeEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            SettingChargeTimeWindow window = new SettingChargeTimeWindow();
            this.IsMaskVisible = true;
            window.ShowDialog();
            this.IsMaskVisible = false;
        }
        /// <summary>
        /// 输入软件注册码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingSoftWareRegistrationKeyEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            SettingSoftwareRegistrationKeyWindow window = new SettingSoftwareRegistrationKeyWindow();
            this.IsMaskVisible = true;
            window.ShowDialog();
            this.IsMaskVisible = false;
        }
        /// <summary>
        /// 更换阀门序列码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingValveNumberEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            SettingValveNumberWindow window = new SettingValveNumberWindow();
            this.IsMaskVisible = true;
            window.ShowDialog();
            this.IsMaskVisible = false;
        }
        /// <summary>
        /// 输入用户授权(lis文件)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingAuthorizationCodeEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            SettingCardPortWindow window = new SettingCardPortWindow();
            this.IsMaskVisible = true;
            window.ShowDialog();
            this.IsMaskVisible = false;
        }
        /// <summary>
        /// 数据库备份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SqlBackupEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            SettingCardPortWindow window = new SettingCardPortWindow();
            this.IsMaskVisible = true;
            window.ShowDialog();
            this.IsMaskVisible = false;
        }
        /// <summary>
        /// 数据恢复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SqlRecoveryEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            SettingCardPortWindow window = new SettingCardPortWindow();
            this.IsMaskVisible = true;
            window.ShowDialog();
            this.IsMaskVisible = false;
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeAddUserActionEvent(object sender, System.Windows.RoutedEventArgs e)
        {
            HomeAddUserActionWindow window = new HomeAddUserActionWindow();
            this.IsMaskVisible = true;
            window.ShowDialog();
            this.IsMaskVisible = false;
        }
        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeEditUserActionEvent(object sender, System.Windows.RoutedEventArgs e)
        {
            HomeAddUserActionWindow window = new HomeAddUserActionWindow();
            this.IsMaskVisible = true;
            window.ShowDialog();
            this.IsMaskVisible = false;
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeDeleteUserActionEvent(object sender, System.Windows.RoutedEventArgs e)
        {
            HomeAddUserActionWindow window = new HomeAddUserActionWindow();
            this.IsMaskVisible = true;
            window.ShowDialog();
            this.IsMaskVisible = false;
        }
        /// <summary>
        /// 用户缴费
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeUserChargeActionEvent(object sender, System.Windows.RoutedEventArgs e)
        {
            HomeUserChargeActionWindow window = new HomeUserChargeActionWindow();
            this.IsMaskVisible = true;
            window.ShowDialog();
            this.IsMaskVisible = false;
        }
        /// <summary>
        /// 缴费统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeChargeAllActionEvent(object sender, System.Windows.RoutedEventArgs e)
        {
            HomeChargeAllActionWindow window = new HomeChargeAllActionWindow();
            this.IsMaskVisible = true;
            window.ShowDialog();
            this.IsMaskVisible = false;
        }
        /// <summary>
        /// 智能卡日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeCardLogActionEvent(object sender, System.Windows.RoutedEventArgs e)
        {
            HomeCardLogActionWindow window = new HomeCardLogActionWindow();
            this.IsMaskVisible = true;
            window.ShowDialog();
            this.IsMaskVisible = false;
        }

        private void MinWindowEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            WindowState = System.Windows.WindowState.Minimized;
        }

        private void MaxWindowEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            if (WindowState == System.Windows.WindowState.Maximized)
            {
                MinimizeIcon.Source = new BitmapImage(new Uri("pack://application:,,,/resources/imgs/max_icon.png",UriKind.Absolute));
                WindowState = System.Windows.WindowState.Normal;
            }
            else
            {
                MinimizeIcon.Source = new BitmapImage(new Uri("pack://application:,,,/resources/imgs/narrow_icon.png", UriKind.Absolute));
                WindowState = System.Windows.WindowState.Maximized;
            }
        }

        private void CloseWindowEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }
        /// <summary>
        /// 复位卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetCardEvetnBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        /// <summary>
        /// 时间卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeCardEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        /// <summary>
        /// 序列号卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberCardEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        /// <summary>
        /// 读卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadCardEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetPwdEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        /// <summary>
        /// 清卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearCardEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        /// <summary>
        /// 账号退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountLogoutEventBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Login window = new Login();
            AppConfigMoel.ClearCache();
            window.Show();
            this.Close();
        }

        private void dataGrid_LoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}
