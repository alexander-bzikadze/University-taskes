#pragma once

#include <vector>

/// Classic stack with vector inside.
template <class T>
class Stack
{
public:
	/// Pushes on top.
	void push(T pushed)
	{
		container.push_back(pushed);
	}

	/// Returnes size of the stack.
	size_t size()
	{
		return container.size();
	}

	/// Returns top.
	T top()
	{
		return *(--container.end());
	}

	/// Pops from top and returns it.
	T pop()
	{
		auto popped = top();
		container.pop_back();
		return popped;
	}

private:
	std::vector<T> container;
};