import React, { useContext, useEffect } from 'react';
import { FlatList, TouchableOpacity, View } from 'react-native';
import FullWidthImage from 'react-native-fullwidth-image';
import { Context } from '../context/TattooContext';
import AppStyles from '../styles/AppStyles';

const HomeScreen = ({ navigation }) => {
  const { state, getTattoos } = useContext(Context);

  useEffect(() => {
    getTattoos();
    const listener = navigation.addListener('didFocus', () => { getTattoos(); });
    return () => { listener.remove(); };
  }, [])

  return (
    <View style={AppStyles.mainView}>
      <FlatList
        data={state}
        keyExtractor={(tattoo) => tattoo.Id}
        showsHorizontalScrollIndicator={false}
        renderItem={({ item }) => {
          return (
            <TouchableOpacity onPress={() => navigation.navigate('Tattoo')}>
              <View>
                <FullWidthImage
                  source={{ uri: 'https://s3.amazonaws.com/ink-peddler-images/prod/tattoo/' + item.AWSImageId }}
                />
              </View>
            </TouchableOpacity>
          );
        }}
      />
    </View>
  );
};

HomeScreen.navigationOptions = ({ navigation }) => {
  return {
    header: null
  };
};

export default HomeScreen;