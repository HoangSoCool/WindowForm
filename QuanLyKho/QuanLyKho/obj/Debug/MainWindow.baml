   M S B A M L   `   `   `  ����D  @QuanLyKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QuanLyKho	QuanLyKho  5   	   ?$clr-namespace:QuanLyKho.UserControlsQuanLyKho.UserControls  5
   	       QuanLyKho.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:QuanLyKho     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   -uc$clr-namespace:QuanLyKho.UserControls  5
   	   _ [MaterialDesignThemes.Wpf, Version=5.2.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��
mainWindow��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    
 MainVM � DataContext# [ 5   	    � Title$! Phần Mềm Quản Lý Kho��5   	   $	��700��6&   $	��640��63   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      6  0System.Windows.Interactivity.InvokeCommandAction  
   Command
 6$   �� *LoadedWindowCommand+   CommandParameter 6L   ��  �� ElementName$ 
mainWindow��5      .��5       �  � RowDefinitions 5!   
   �� 5"      $
��auto �6   6,   �� 5#      6   .+�5%   
   � $��0��6   .+�5&      )   #QuanLyKho.UserControls.ControlBarUC  
 � Tag 6   �� *Title+$ 
mainWindow��6O   5'      � 5)   
   $��1��6    5*      �� 5+      $
��auto �6    60   �� 5,      6"   .+�50      � $��0��6   .+�53      � $��Stretch=�6   $��Stretch=�65   
������  � 	Resources 54       �� 
TargetType �� Property �� Value��%V   '��       �� 55      " ��6    .�56      ��  � ��$ 5q�67   6C   57      58       � ColumnDefinitions 59      �� 5:      6-   �� 5;      6-   �� 5<      6-   �� 5=      6-   �� 5>      6-   �� 5?      6-   �� 5@      6-   .+�5B      �� $��0��6    � ToolTip$ 
Nhập kho��6N   ��6-   �� *InputCommand+.��5C      �  5D      �� 5E   "   62   �� 5F   "   62   .+�5H      � $��0��6#   .+�5I   "   �� $��
Nhập kho��6,   $��Center=�6<   6[   5K      � 5M      $��1��6#   .+�5N   "   '  !MaterialDesignThemes.Wpf.PackIcon  $��Center=�6:   $��24��6W   $��24��6b      Kind$ BasketUnfill=�6o   5O      5P      5Q      �� 5S      $��1��6   $ 
Xuất kho��6O   ��6-   �� *OutputCommand+.��5T      �  5U      �� 5V   "   62   �� 5W   "   62   .+�5Y      � $��0��6#   .+�5Z   "   �� $��
Xuất kho��6,   $��Center=�6<   6[   5\      � 5^      $��1��6#   .+�5_   "     $��Center=�6:   $��24��6W   $��24��6b   $ 
BasketFill=�6o   5`      5a      5b      �� 5d      $��2��6   $ 	Vật tư��6O   ��6-   �� *ObjectCommand+.��5e      �  5f      �� 5g   "   62   �� 5h   "   62   .+�5j      � $��0��6#   .+�5k   "   �� $��	Vật tư��6,   $��Center=�6:   6Y   5m      � 5o      $��1��6#   .+�5p   "     $��Center=�6:   $��24��6W   $��24��6b   $ Database=�6o   5q      5r      5s      �� 5u      $��3��6   $ Đơn vị đo��6M   ��6-   �� *UnitCommand+.��5v      �  5w      �� 5x   "   62   �� 5y   "   62   .+�5{      � $��0��6#   .+�5|   "   �� $��Đơn vị đo��6,   $��Center=�6=   6\   5~      � 5�      $��1��6#   .+�5�   "     $��Center=�6:   $��24��6W   $��24��6b   $ 	Altimeter=�6o   5�      5�      5�      �� 5�      $��4��6   $ Nhà cung cấp��6P   ��6-   �� *SuplierCommand+.��5�      �  5�      �� 5�   "   62   �� 5�   "   62   .+�5�      � $��0��6#   .+�5�   "   �� $��Nhà cung cấp��6,   $��Center=�6@   6_   5�      � 5�      $��1��6#   .+�5�   "     $��Center=�6:   $��24��6W   $��24��6b   $ Factory=�6o   5�      5�      5�      �� 5�      $��5��6   $ Khách hàng��6Q   ��6-   �� *CustomerCommand+.��5�      �  5�      �� 5�   "   62   �� 5�   "   62   .+�5�      � $��0��6#   .+�5�   "   �� $��Khách hàng��6,   $��Center=�6>   6]   5�      � 5�      $��1��6#   .+�5�   "     $��Center=�6:   $��24��6W   $��24��6b   $ HumanGreeting=�6o   5�      5�      5�      �� 5�      $��6��6   $ Người dùng��6M   ��6-   �� *UserCommand+.��5�      �  5�      �� 5�   "   62   �� 5�   "   62   .+�5�      � $��0��6#   .+�5�   "   �� $��Người dùng��6,   $��Center=�6>   6]   5�      � 5�      $��1��6#   .+�5�   "     $��Center=�6:   $��24��6W   $��24��6b   $ 
AccountKey=�6o   5�      5�      5�      5�      5�      � 5�      $��1��6    5�      �� 5�      $
��auto �6$   64   �� 5�      6&   .+�5�      � $��0��6   5�      � 5�      $��0��6   .+�5�      #  MaterialDesignThemes.Wpf.Card  $��5q�6*   .��5�      � $��0��6   
������� 5�      �� 5�   "   $
��auto �60   6@   �� 5�   "   $
��auto �60   6@   �� 5�   "   62   .+�5�      � $��0��6#   $��5q�60    5�   "   �� 5�   &   $
��auto �67   6F   �� 5�   &   $
��auto �67   6F   �� 5�   &   $
��auto �67   6F   .+�5�   "   � $��0��6'   $��15q�67   .+�5�   &   (	  "System.Windows.Controls.DatePicker	  $��Center=�5�   %   $
��Left=�5�   %   $	��100��5�   %   )
  #MaterialDesignThemes.Wpf.HintAssist 
  Hint$ Ngày bắt đầu��5�   %    ( $MaterialDesignFloatingHintDatePicker#��[ 5�   %   5�   #   � 5�   "   $��1��6'   $��15q�67   .+�5�   &   	  $��Center=�5�   %   $
��Left=�5�   %   $	��100��5�   %   $ Ngày kết thúc��5�   %   #��[ 5�   %   5�   #   � 5�   "   $��2��6'   .+�5�   &   �� $��5q�5�   %     MaterialDesignRaisedButton#��[ 5�   %   $	��100��5�   %   $��Lọc��5�   %   $/ )Resource name: MaterialDesignRaisedButton��5�   %   5�   '   5�   #   5�      � 5�      $��1��6#   .+�5�   "   �� $��5q�6,   69   5�      � 5�      $��2��6#    5�   "   �� 5�   &   $
��auto �67   6F   �� 5�   &   $
��auto �67   6F   �� 5�   &   $
��auto �67   6F   .+�5�   "   � $��0��6'   .+�5�   &     $��5q�6:   ���#03a9f4 ! PrimaryHueDarkForegroundBrush#���  5�   '   $��0q�5�   '   $	��200��5�   '   .��5   *   �  5  .   �� 5  2   $
��Auto �6@   �� 5  2   $
��Auto �6@   �� 5  2   $
��Auto �6@   .+�5  .   �� $��Lượng Nhập��5  /   $��0��5  /   $��
16 16 16 4q�5	  /   5
  /   �� 5  .   $��1��5        MaterialDesignLightSeparator#��[ 5     �� 5  .   $��1��5     $��16,20,-63,0q�5     $	��Top=�5        MaterialDesignBody2TextBlock#��[ 5     $��2��6E   ��5     �� *
TotalInput+5  E   '  !MaterialDesignThemes.Wpf.PopupBox  5  .   $��Right=�5     $��2 0 2 0q�5        PopupContent. 5  2   �� .+�5  6   �� $
��More��5     �� 5  6   $��Options��5     5  3   5  /   5   +   5!  '   5"  #   � 5$  "   $��1��6'   .+�5%  &     $��5q�6:   ���#03a9f4#���  5'     $��0q�5(     $	��200��5)     .��5*  *   �  5+  .   �� 5,  2   $
��Auto �6@   �� 5-  2   $
��Auto �6@   �� 5.  2   $
��Auto �6@   .+�50  .   �� $��Lượng Xuất��51     $��0��52     $��
16 16 16 4q�53     54  /   �� 55  .   $��1��56     #��[ 57     �� 58  .   $��2��59     $��	16 0 16 8q�5:     $��Center=�5;     $
��Left=�5<     #��[ 5>     ��5=     �� *TotalOutput+5?  /     5B  .   $��Right=�5C     $��2 0 2 0q�5D     . 5E  2   �� .+�5F  6   �� $
��More��5G     �� 5H  6   $��Options��5I     5J  3   5K  /   5L  +   5M  '   5N  #   � 5P  "   $��2��6'   .+�5Q  &     $��5q�6:   ���#03a9f4#���  5S     $��0q�5T     $	��200��5U     .��5V  *   �  5W  .   �� 5X  2   $
��Auto �6@   �� 5Y  2   $
��Auto �6@   �� 5Z  2   $
��Auto �6@   .+�5\  .   �� $��	Tồn Kho��5]     $��0��5^     $��
16 16 16 4q�5_     5`  /   �� 5a  .   $��1��5b     #��[ 5c     �� 5d  .   $��2��5e     $��	16 0 16 8q�5f     $��Center=�5g     $
��Left=�5h     #��[ 5j     ��5i     �� *Total+5k  /     5n  .   $��Right=�5o     $��2 0 2 0q�5p     . 5q  2   �� .+�5r  6   �� $
��More��5s     �� 5t  6   $��Options��5u     5v  3   5w  /   5x  +   5y  '   5z  #   5{     5}     5�     5�       5�     $��1��6&   $��5q�63   $��Stretch=�6>   .��5�     �  5�     �� 5�     $
��453* �6/   �� 5�     $	��22* �6/   �� 5�     $
��155* �6/    5�     �� 5�     $
��auto �6,   6<   �� 5�     $
��auto �6,   6<   �� 5�     6.   .+�5�     � $��0��6   $��5,5,5,5q�6,   $��3��6=    5�     �� 5�  "   $
��auto �63   6B   �� 5�  "   $
��auto �63   6B   �� 5�  "   $
��auto �63   6B   .+�5�     � $��0��6#   $��15q�63   .+�5�  "   	  $��Center=�5�  	   $
��Left=�5�  	   $	��100��5�  	   $ Ngày bắt đầu��5�  	   #��[ 5�  	   5�     � 5�     $��1��6#   $��15q�63   .+�5�  "   	  $��Center=�5�  	   $
��Left=�5�  	   $	��100��5�  	   $ Ngày kết thúc��5�  	   #��[ 5�  	   5�     � 5�     $��2��6#   .+�5�  "   �� $��5q�5�     #��[ 5�     $	��100��5�     $��Lọc��5�     $/ )Resource name: MaterialDesignRaisedButton��5�     5�  #   5�     5�     � 5�     $��1��6   $��3��6,   .+�5�     �� 6*   5�     � 5�     $��2��6   $��3��6,   .+�5�     �� ��6'   �� *InventoryList+ �� View 5�  "   �� 5�  &   .P�5�  *   �� $	��STT��69    �� DisplayMemberBinding 6F   �� *STT+6m   �� 5�  *   $��Tên Vật Tư��69    6M   �� *Object.DisplayName_Object+6�   �� 5�  *   $��Số Lượng Tồn��69   -   5        
txtSLT�� 5�  _   �� *Amount+6�   5�  '   5�     5�     5�     5�     5�     5�     5�     5�     