   M S B A M L   `   `   `  ����M  ITemperaturePlotter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TemperaturePlotterTemperaturePlotter  5   	   #    TemperaturePlotter.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:TemperaturePlotter     5   	   R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5   
   -   5          � Title$  Temperature Monitor��5	   	   $	��700��6%   $	��900��62    � 
ResizeMode$ NoResize=�6>   $��2q�6T    � WindowStartupLocation$ CenterScreen=�6h   ���	#FF92A5AC���	#FF1F1313 � DataContext 5
      4   .TemperaturePlotter.DataSamplerViewModelContext  5   
    � 	Resources 5         DisabledForegroundBrush �� Color  DisabledBackgroundBrush �� 
TargetType �� Property �� Value	 �� 
TargetType
 J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName��%q  &	        &	      '�� >     7  7   �� 5   
   $ White��6:   �� 5   
   $ White��6:   �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��
 �   �6,   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� #��z��6!   #��z��5   .   #��z��5   .   
 . ._�5      �� $��PART_ContentHost��6+   #��z��6C   #
 z
 5   +   5       5      P� 5       � {� .  . �5   "   �� 8    � ��6Z   �� 5    "   8   � ��6Z   �� 5!   "   $ PART_ContentHost��6)    � �� �#aaaa6]   5"      5$      5&      5'      5(       J� OpacityMask 5)      �� 5*   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5+      �  � Color$ Black��6    � Offset$ 0Q�6)   � 5,      $ White��6   $ 1Q�6)   5-      .��5/      ��  �� Padding$ 10q�6   ._�50   
   � $��0 3 0 0q�6    � ColumnDefinitions 51      �� 52      $��* �6#   �� 53      $��* �6#   �� 54      $��1* �6#    � RowDefinitions 56      �� 57      $��* �6    �� 58      $��4* �6    .+�5;      �� $��0��6   .+�5<      �� $��Avg Temperature��6   $��80,5,0,0q�63    � ToolTip$+ %Show Average temporature for last 10s��6E   �� 5=      -   5         ��Name$ 
StatusText��5=       �� 
IsReadOnly . $��2q�6@   $��
50,0,100,0q�6L   ���#eee$. (Showing Average temperature for last 10s��6r   ��6�   �� *AverageTemperature+�� 5>      $	��RSD��6   $��	80 10 0 0q�6'   $+ %Show Average temporature for last 10s��6:   �� 5?      -   5        $
 sdsd��5?       . $��2q�6:   $��
50,0,100,0q�6F   ���#eee$ Showing RSD for last 10s��6l   ��6�   �� *
RsdValue+�� 5@       �� Orientation$ 
Horizontal=�6   .+�5A      �� $��
50,10,10,0q�6   $��60��61   $��20��6>   ��5B      �� *Status+�� 5C      $��
10,10,50,0q�6!   $	��150��65   $��20��6C   ��6O   �� *StatbilityStatus+5D      5E      �� 5G      $��0��6   $��2��6&   .+�5H      �� $��File For Sampling��6   $��00 0 0 0q�65   $+ %Show Average temporature for last 10s��6G   �� 5I      $ 
Horizontal=�6   .+�5J      �� -   5        $ sd��5J       .  $��2q�6=   $	��150��6I   $��0,0,0,20q�6U   $  Path for the Sampling file��6h   ��6�   ��  �� Path$ FilePath� �� Mode$ TwoWay=�{�6�   �� $ EnableContents��� 5K      -   5        $��Browse��5K      $��80��6+   $��
10,0,10,20q�66   $��Browse��6J   {�6p   �� $ EnableContents�6�   5L      �� 5M      $ 
Horizontal=�6   {�66   �� $ EnableContents�.+�5N      �� $��0,0,0,30q�6J   $��
Use Filter��6�   {�6   �� $ EnableContents� d� 	IsChecked 6\   �� $ 	UseFilter�6�   �� 5O      .+�5P      �� $��2q�6"   $��
10,-3,10,2q�6.   $B <Input to Moving Average Filter.Uses 6 samples for wrong data��6�   ��6C   �� $ NoOfSamples�$ TwoWay=�{�6r   �� $ 	UseFilter�6�   �� 5Q      $��No Of Samples��6$   $��	10,0,10,2q�69   5R      5S      �� 5U      -   5        $��	StartStop��5U      $��0,0,80,0q�6*   ��6<   �� *StartButtonText+��6`   �� *ButtonCommand+6�   5V      �� 5Y      $��1��6   $��0��6&   $��3��66   .+�5Z        OxyPlot.Wpf.Plot  -   5        $��
OxyPlotter��5Z      $��-60,0q�6E   $	��850��6T   $	��500��6`      Title 6-   �� *Title+   Series 5[        OxyPlot.Wpf.LineSeries  5\      ��6)   �� *Points+5^      5_      5`      5a      5b      