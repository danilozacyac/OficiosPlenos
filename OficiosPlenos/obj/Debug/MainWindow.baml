   M S B A M L   `   `   `  ����H  DOficiosPlenos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:OficiosPlenos.ConverterOficiosPlenos.Converter  5   	   E AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls 5   	       OficiosPlenos.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;	Converter%clr-namespace:OficiosPlenos.Converter     5   	   C
UIControls,clr-namespace:UIControls;assembly=UIControls     5   	   p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n
 jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
  5   	   -   5          � Title$  
MainWindow��5   	   $	��525��5   	   $	��350��5	   	    � Icon$ Resources/postal.png��5
   	    � 	Resources 5      0  *OficiosPlenos.Converter.EncargadoConverter   	encarConv��%   &	          5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ,  &Telerik.Windows.Controls.RadRibbonView  $	��Top=�6    .@�5      +  %Telerik.Windows.Controls.RadRibbonTab  $��Herramientas��6#   .@�5      -  'Telerik.Windows.Controls.RadRibbonGroup  $��	Admisión��6)   .@�5      .  (Telerik.Windows.Controls.RadRibbonButton  -   5          Name$ BtnAgregarContra��5   .   $��Agregar��5   .      
LargeImage$ Resources/add.png��5   .      Size$ Large=�5   .     5      -   5        $ BtnEditaContra��5   .   $��Editar��5!   .   $ Resources/edit.png��5"   .   $ Large=�5#   .   5%        5&      $��Secretaría General��6)   .@�5'        -   5        $ BtnSga��5'   .   $��Oficios Sga��5)   .   $ Resources/sga.png��5*   .   $ Large=�5+   .   5-        5.      $��Plenos de Circuito��6)   .@�5/        -   5        $ BtnOficioPlenos��5/   .   $��Oficios Plenos��51   .   $ Resources/plenos.png��52   .   $ Large=�53   .   54        55      $��
Encargados��6)   .@�56        -   5        $ AddEncargado��56   .   $ Resources/addUser.png��58   .   $ Large=�59   .   .��5:      ��  �� Orientation$ Vertical=�6%   .+�5;      �� $��Center=�6(   $��Agregar��6E   �� 5<      $��Center=�6(   $��	Encargado��6E   5=      5>      5@      5A      5B        UIControls.SearchTextBox  5D   
   -   5        $��1��5D   #      	LabelText$1 +Buscar por Pleno de Circuito o Encargado...��5E   #   5F   #   * 
 $Telerik.Windows.Controls.RadGridView  5H   
   -   5        	  Name$	 GContra��5H      $��2��5I      $��Stretch=�5J      $��Stretch=�5K      ; 
 5Telerik.Windows.Controls.GridView.GridViewDataControl
   AutoGenerateColumns
 .  $��16(�5M         ShowGroupPanel .  *	  $Telerik.Windows.Controls.DataControl 	  ItemsSource 5N      ��    Columns 5Q      1
 
 +Telerik.Windows.Controls.GridViewDataColumn
  5R      - 
 'Telerik.Windows.Controls.GridViewColumn   Width? 
 9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ * 6-   6 
 0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$ Pleno��5T   -      IsFilterable .     DataMemberBinding 5S   -   �� *
PlenoStr+5U   -   
  5V      $ * 6-   $ 	Encargado��5X   -    .   5W   -   �� *EncargadoStr+5Y   -   
  5Z      $ 80 6-   $ Asunto��5\   -    5[   -   �� *	NumAsunto+5\   -   
  5]      $ 80 6-   $
 Año��5_   -    5^   -   �� *
AnioAsunto+5_   -   
  5`      $	 150 6-   $ Oficio Admisión��5b   -    .   5a   -   �� *OficioAdmision+5c   -   5e      5g      5h      